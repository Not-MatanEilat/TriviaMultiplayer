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
	 	TRACE("MenuHandler " << m_user.getUsername() << ": " << error.message)
	 	result.response = JsonResponsePacketSerializer::serializeResponse(error);
	 	result.newHandler = this;
	}

	return result;
 }




