#include "RoomManager.h"

/**
 * \brief Constructor for the RoomManager
 */
RoomManager::RoomManager()
{

}


void RoomManager::createRoom(const LoggedUser& user, const RoomData& roomData)
{
	Room room(roomData);
	room.addUser(user);

	// check if id already exists
	for (auto& room : m_rooms)
	{
		if (room.first == roomData.id)
		{
			throw std::exception("Room id already exists in the vector");
		}
	}

	m_rooms[roomData.id] = room;
}

