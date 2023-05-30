#include "RoomMemberRequestHandler.h"

#include "JsonResponsePacketSerializer.h"

/**
 * \brief The constructor for RoomMemberRequestHandler
 * \param handlerFactory The factory handler
 * \param user the user that has joined the room that is in
 * \param room the room the user has already created
 */
RoomMemberRequestHandler::RoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, const LoggedUser& user, Room& room) :
	m_room(room), m_user(user), m_roomManager(handlerFactory.getRoomManager()), m_handlerFactory(handlerFactory)
{
}

/**
 * \brief Checks if the request is relevant to the handler
 * \param info the request info
 * \return true if the request is relevant, false otherwise
 */
bool RoomMemberRequestHandler::isRequestRelevant(RequestInfo info)
{
	int code = info.requestId;
	return code == LEAVE_ROOM_CODE || code == ROOM_STATE_CODE;
}

/**
 * \brief Handlers the request as the menu
 * \param info the info of request
 * \return The result for request
 */
RequestResult RoomMemberRequestHandler::handleRequest(RequestInfo info)
{
	RequestResult result;
	result.newHandler = this;
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
		TRACE("RoomMemberHandler " << m_user.getUsername() << ": " << error.message)
			result.response = JsonResponsePacketSerializer::serializeResponse(error);
		result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);


	}
	return result;
}

/**
 * \brief handles client disconnecting
 */
void RoomMemberRequestHandler::handleDisconnect()
{
	TRACE("RoomMemberHandler " << m_user.getUsername() << ": disconnected")
	m_roomManager.leaveRoom(m_user);
	m_handlerFactory.getLoginManager().logout(m_user.getUsername());
}

/**
 * \brief leave the room
 * \param info request info
 * \return the leave room result
 */
RequestResult RoomMemberRequestHandler::leaveRoom(RequestInfo info)
{
	RequestResult result;

	LeaveRoomResponse response;

	m_roomManager.leaveRoom(m_user);
	response.status = SUCCESS;

	result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	result.response = JsonResponsePacketSerializer::serializeResponse(response);


	TRACE("User: " + m_user.getUsername() + " has left the room: " + std::to_string(m_room.getRoomData().id));

	return result;
}

/**
 * \brief get the room state
 * \param info request info
 * \return the room state result
 */
RequestResult RoomMemberRequestHandler::getRoomState(RequestInfo info)
{
	RequestResult result;

	GetRoomStateResponse response;

	response.answerTimeout = m_room.getRoomData().timePerQuestion;
	response.hasGameBegun = m_room.getRoomData().isActive;
	response.players = m_room.getAllUsernames();
	response.questionCount = m_room.getRoomData().numOfQuestionsInGame;
	response.status = SUCCESS;

	result.newHandler = this;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);

	string playersStr = "";
	for (const auto& player : response.players)
	{
		playersStr += player + " ";
	}
	TRACE("\nGetting room state by user: " + m_user.getUsername() + "\n"
		"AnswerTimeout: " + std::to_string(response.answerTimeout) + "\n"
		+ "HasGameBegun: " + std::to_string(response.hasGameBegun) + "\n"
		+ "Players: " + std::to_string(response.players.size()) + "\n"
		+ "QuestionCount: " + std::to_string(response.questionCount) + "\n"
		+ "Players: " + playersStr + " \n");

	return result;

}
