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
 * \param id the id of the room to there delete
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

/**
 * \brief The function will get the current RoomState, if the room is active, then we return IN_GAME, else we return WAITING
 * If roomId doesn't exist, we throw an exception
 * \param id the if od the room to get the state of off
 * \return IN_GAME OR WAITING
 */
unsigned int RoomManager::getRoomState(int id)
 {

	// check if room exists even
	if (m_rooms.find(id) == m_rooms.end())
	{
		throw std::exception("Room was not found");
	}

	if (m_rooms[id].getRoomData().isActive)
	{
		return IN_GAME;
	}

	return WAITING;
	
	 
 }


/**
 * \brief The function returns a vector of the roomData of all of the rooms
 * \return Vector of the roomData
 */
vector<RoomData> RoomManager::getRooms() const
{
	vector<RoomData> rooms;
	for (const auto& room : m_rooms)
	{
		rooms.push_back(room.second.getRoomData());
	}
	return rooms;
}


/**
 * \brief The function returns a room by the given id, if the room doesn't exist, we throw an exception
 * \param id the id of the room to get
 * \return Room of the given id
 */
Room& RoomManager::getRoom(int id)
{
	// check if room exists, if not, then throw an exception
	if (m_rooms.find(id) == m_rooms.end())
	{
		throw std::exception("Room was not found");
	}

	return m_rooms[id];
}






