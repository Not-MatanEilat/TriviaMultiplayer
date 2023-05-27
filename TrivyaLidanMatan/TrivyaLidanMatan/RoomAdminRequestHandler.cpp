#include "RoomAdminRequestHandler.h"

#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h""

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

