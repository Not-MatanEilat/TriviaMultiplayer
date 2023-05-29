#include "RoomMemberRequestHandler.h"

#include "JsonResponsePacketSerializer.h"

RoomMemberRequestHandler::RoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, const LoggedUser& user, Room& room) :
	m_room(room), m_user(user), m_roomManager(handlerFactory.getRoomManager()), m_handlerFactory(handlerFactory)
{
}

bool RoomMemberRequestHandler::isRequestRelevant(RequestInfo info)
{
	int code = info.requestId;
	return code == LEAVE_ROOM_CODE || code == ROOM_STATE_CODE;
}

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
		TRACE("MenuHandler " << m_user.getUsername() << ": " << error.message)
			result.response = JsonResponsePacketSerializer::serializeResponse(error);
		result.newHandler = this;
	}
	return result;
}

RequestResult RoomMemberRequestHandler::leaveRoom(RequestInfo info)
{
	RequestResult result;

	LeaveRoomResponse response;

	m_roomManager.leaveRoom(m_user);
	response.status = SUCCESS;

	result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}

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
	return result;
}
