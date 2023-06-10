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
