#include "HeadToHeadRoomHandler.h"

/**
 * \brief The constructor for HeadToHeadRoomHandler
 * \param handlerFactory The factory handler currently
 * \param user the user in room
 * \param room the current room user's in
 */
HeadToHeadRoomHandler::HeadToHeadRoomHandler(RequestHandlerFactory& handlerFactory, const LoggedUser& user, Matchmaker& matchmaker) :
	m_matchmaker(matchmaker), m_user(user), m_matchmakerManager(handlerFactory.getMatchmakerManager()), m_handlerFactory(handlerFactory)

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
	return code == LEAVE_ROOM_CODE || code == ROOM_STATE_CODE;
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
		if (info.requestId == LEAVE_ROOM_CODE)
		{
			result = leaveRoom(info);
		}
		else if (info.requestId == ROOM_STATE_CODE)
		{
			result = getRoomState(info);
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

RequestResult HeadToHeadRoomHandler::leaveRoom(RequestInfo info)
{
	RequestResult result;
	LeaveRoomResponse response;
	response.status = SUCCESS;
	m_roomManager.deleteRoom(m_room.getId());
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	return result;
}

