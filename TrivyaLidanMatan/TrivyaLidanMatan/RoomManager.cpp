#include "RoomManager.h"

/**
 * \brief Constructor for the RoomManager
 */
RoomManager::RoomManager()
{

}

/**
 * \brief Creates a new a room, checks if the id given already exists, if it is, then we throw an exception
 * \param user the user who created the room
 * \param roomData the data of room
 */
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

/**
 * \brief The function deletes a room from the vector by the id, if the room doesn't exist, we throw an exception
 * \param id 
 */
void RoomManager::deleteRoom(unsigned int id)
{
	bool isRoomFound = false;
	for (const auto& room : m_rooms)
	{
		if (room.first == id)
		{
			m_rooms.erase(id);
			isRoomFound = true;
			break;
		}
	}

	if (!isRoomFound)
	{
		throw std::exception("Room was not found");
	}
}



