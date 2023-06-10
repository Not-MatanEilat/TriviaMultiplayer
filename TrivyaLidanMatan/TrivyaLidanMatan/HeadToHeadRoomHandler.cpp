#include "HeadToHeadRoomHandler.h"

/**
 * \brief The constructor for HeadToHeadRoomHandler
 * \param handlerFactory The factory handler currently
 * \param user the user in room
 * \param room the current room user's in
 */
HeadToHeadRoomHandler::HeadToHeadRoomHandler(RequestHandlerFactory& handlerFactory, const LoggedUser& user, Room& room) :
	m_room(room), m_user(user), m_roomManager(handlerFactory.getRoomManager()), m_handlerFactory(handlerFactory)

{
	
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
