#include "RoomAdminRequestHandler.h"

#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

/**
 * \brief Checks if the given request is relevant to the handler
 * \param info the request info given
 * \return True or False
 */
bool RoomAdminRequestHandler::isRequestRelevant(RequestInfo info)
{
	int code = info.requestId;
	return code == CLOSE_ROOM_CODE || code == ROOM_STATE_CODE || code == START_GAME_CODE;
}

/**
 * \brief The function will handle the admin user of the current room
 * \param info the info of request
 * \return the result for request
 */
RequestResult RoomAdminRequestHandler::handleRequest(RequestInfo info)
 {
	int code = info.requestId;
	RequestResult result;
	try
	{
		if (code == CLOSE_ROOM_CODE)
		{
			result = closeRoom(info);
		}
		else if (code == ROOM_STATE_CODE)
		{
			result = getRoomState(info);
		}
		else if (code == START_GAME_CODE)
		{
			result = startGame(info);
		}
	}
	catch (const std::exception& e)
	{
		ErrorResponse error;
	 	error.message = "Something went wrong: " + std::string(e.what());
	 	TRACE("RoomAdminHandler " << m_user.getUsername() << ": " << error.message)
	 	result.response = JsonResponsePacketSerializer::serializeResponse(error);
	 	result.newHandler = this;
	}

	return result;
 }

/**
 * \brief The function will close the room by deleting it
 * \param info the info of request
 * \return the result for request, error if thre was an error in process
 */
RequestResult RoomAdminRequestHandler::closeRoom(RequestInfo info)
{
	RequestResult result;
	try
	{
		m_roomManager.deleteRoom(m_room.getRoomData().id);

		CloseRoomResponse response;
		response.status = SUCCESS;

		result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
		result.response = JsonResponsePacketSerializer::serializeResponse(response);
	}
	catch (const std::exception& e)
	{
		ErrorResponse error;
		error.message = "Something went wrong: " + std::string(e.what());
		TRACE("RoomAdminHandler " << m_user.getUsername() << ": " << error.message);
		result.response = JsonResponsePacketSerializer::serializeResponse(error);
		result.newHandler = this;
	}

	return result;

}

/**
 * \brief The function will return the result with the current state of the room
 * \param info the info of request
 * \return the response of request, if gotten an error then will return an error response
 */
RequestResult RoomAdminRequestHandler::getRoomState(RequestInfo info)
{
	RequestResult result;

	try
	{
		GetRoomStateResponse response;
		response.status = SUCCESS;
		response.answerTimeout = m_room.getRoomData().timePerQuestion;
		response.hasGameBegun = m_room.getRoomData().isActive;

		for (auto& player : m_room.getAllUsers())
		{
			response.players.push_back(player.getUsername());
		}

		response.questionCount = m_room.getRoomData().numOfQuestionsInGame;

		result.newHandler = this;
		result.response = JsonResponsePacketSerializer::serializeResponse(response);
	}
	catch (const std::exception& e)
	{
		ErrorResponse error;
		error.message = "Something went wrong: " + std::string(e.what());
		TRACE("RoomAdminHandler " << m_user.getUsername() << ": " << error.message);
		result.newHandler = this;
		result.response = JsonResponsePacketSerializer::serializeResponse(error);
	}

	return result;
}






