#include "Room.h"

/**
 * \brief C'tor for the room
 * \param metadata the data of room
 */
Room::Room(const RoomData& metadata): m_metadata(metadata)
{
		
}

/**
 * \brief Function will add a user to the current room
 * \param user the user to add
 */
void Room::addUser(LoggedUser user)
{
	m_users.push_back(user);
}


