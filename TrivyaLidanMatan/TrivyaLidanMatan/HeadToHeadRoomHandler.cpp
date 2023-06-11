#include "HeadToHeadRoomHandler.h"

/**
 * \brief The constructor for HeadToHeadRoomHandler
 * \param handlerFactory The factory handler currently
 * \param user the user in room
 * \param room the current room user's in
 */
HeadToHeadRoomHandler::HeadToHeadRoomHandler(RequestHandlerFactory& handlerFactory, const LoggedUser& user, Matchmaker& matchmaker) :
	m_matchmaker(matchmaker), m_user(user), m_handlerFactory(handlerFactory)

{
	matchmaker.addPlayer(m_user);
}

/**
 * \brief Will return a bool based on if the request was relevant or not
 * \param info the info of request
 * \return True or False
 */
bool HeadToHeadRoomHandler::isRequestRelevant(RequestInfo info)
{
	int code = info.requestId;
	return code == LEAVE_HTH_CODE || code == HTH_GET_STATE_CODE;
}

/**
 * \brief Handles the Head To Head room
 * \param info the info of request
 * \return the result of request
 */
RequestResult HeadToHeadRoomHandler::handleRequest(RequestInfo info)
{
	RequestResult result;

	try
	{
		if (info.requestId == LEAVE_HTH_CODE)
		{
			result = leaveRoom(info);
		}
		else if (info.requestId == HTH_GET_STATE_CODE)
		{
			result = getState(info);
		}


	}
	catch (const std::exception& e)
	{
		ErrorResponse error;
		error.message = "Something went wrong: " + std::string(e.what());
		TRACE("HeadToHeadRequestHandler " << m_user.getUsername() << ": " << error.message)
			result.response = JsonResponsePacketSerializer::serializeResponse(error);
		result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);

	}

	m_matchmaker.handleMatchmaking();
	return result;
}

/**
 * \brief Will handle a user whenever they have disconnected
 */
void HeadToHeadRoomHandler::handleDisconnect()
{
	TRACE("HeadToHeadRoomHandler " << m_user.getUsername() << ": disconnected");
	m_matchmaker.removePlayer(m_user);
	m_handlerFactory.getLoginManager().logout(m_user.getUsername());
}


/**
 * \brief Will let the user know if a game was found
 * \param info the info of request
 * \return the result of request
 */
RequestResult HeadToHeadRoomHandler::getState(RequestInfo info)
{
	RequestResult result;
	getHTHStateResponse response;


	response.status = SUCCESS;

	if (m_matchmaker.isPlayerInQueue(m_user))
	{
		response.hasGameBegun = false;
		result.newHandler = this;
	}
	else
	{
		response.hasGameBegun = true;
		result.newHandler = m_handlerFactory.createGameRequestHandler(m_user, m_handlerFactory.getGameManager().getGame(m_user));
	}

	result.response = JsonResponsePacketSerializer::serializeResponse(response);

	return result;
}


/**
 * \brief Will remove player from the current matchmaking
 * \param info info of the request
 * \return the result of request
 */
RequestResult HeadToHeadRoomHandler::leaveRoom(RequestInfo info)
{
	RequestResult result;
	LeaveHTHResponse response;

	m_matchmaker.removePlayer(m_user);

	response.status = SUCCESS;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	return result;
}

