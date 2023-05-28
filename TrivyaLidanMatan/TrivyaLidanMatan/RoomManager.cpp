#include "RoomManager.h"

#include "Helper.h"

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
	// check if id already exists
	for (auto it = m_rooms.begin(); it != m_rooms.end(); it++)
	{
		if ((*it).first == roomData.id)
		{
			throw std::exception("Room id already exists in the vector");
		}
	}

	Room room(roomData);


	std::pair<int, Room> pair(roomData.id, room);
	m_rooms.insert(pair);

	TRACE("\nRoom created, Creator of the room: " + user.getUsername() + ", Room Data:\n"
		"Id: " + std::to_string(roomData.id) + "\n"
		"Room Name: " + roomData.name + "\n"
		"Is Active: " + std::to_string(roomData.isActive) + "\n"
		"Number of Questions: " + std::to_string(roomData.numOfQuestionsInGame) + "\n"
		"Max Players: " + std::to_string(roomData.maxPlayers) + "\n"
		"Time Per a Question: " + std::to_string(roomData.timePerQuestion) + "\n");


	joinRoom(user, room.getRoomData().id);
}

/**
 * \brief Will let the user join the room he wants, if user already in a room, we throw an exception,
 * if room doesn't exsit we throw an exception
 * \param user the user that joins
 * \param id id of room joining
 */
void RoomManager::joinRoom(const LoggedUser& user, unsigned id)
{
	if (isUserInAnyRoom(user.getUsername()))
	{
		throw std::exception("User already in a room");
	}

	if (!doesRoomExist(id))
	{
		throw std::exception("Room was not found");
	}

	Room& room = getRoom(id);
	room.addUser(user);

	TRACE("Room Joined, User that has joined: " + user.getUsername() + ", Room that got joined: " + std::to_string(id));
}

/**
 * \brief The function deletes a room from the vector by the id, if the room doesn't exist, we throw an exception
 * \param id the id of the room to there delete
 */
void RoomManager::deleteRoom(unsigned int id)
{
	if (!doesRoomExist(id))
	{
		throw std::exception("Room was not found");
	}

	for (const auto& room : m_rooms)
	{
		if (room.first == id)
		{
			m_rooms.erase(id);
			break;
		}
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

	if (!doesRoomExist(id))
	{
		throw std::exception("Room was not found");
	}

	if (m_rooms.at(id).getRoomData().isActive)
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
	if (!doesRoomExist(id))
	{
		throw std::exception("Room was not found");
	}

	return m_rooms.at(id);
}

/**
 * \brief 
 * \param username 
 * \return 
 */
Room& RoomManager::getRoomOfUser(const string& username)
{
	for (auto& room : m_rooms)
	{
		for (const auto& loggedUser : m_rooms.at(room.first).getAllUsers())
		{
			if (loggedUser.getUsername() == username)
			{
				return room.second;
			}
		}
	}
	throw std::exception("User is not in any room");
}

/**
 * \brief check if user is already in any room
 * \param username the username to check
 * \return True or False
 */
bool RoomManager::isUserInAnyRoom(const string& username)
{
	try
	{
		Room& room = getRoomOfUser(username);
		return true;
	}
	catch (const std::exception&)
	{
		return false;
	}
}

/**
 * \brief Checks if there is a room that exists with the given id there
 * \param id the id to check if any room exists with it
 * \return True or False
 */
bool RoomManager::doesRoomExist(unsigned id)
{
	return m_rooms.find(id) != m_rooms.end();
}








