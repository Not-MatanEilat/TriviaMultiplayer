#include "Room.h"

/**
 * \brief C'tor for the room
 * \param metadata the data of room
 */
Room::Room(const RoomData& metadata): m_roomData(metadata)
{
		
}

/**
 * \brief Function will add a user to the current room
 * \param user the user to add
 */
void Room::addUser(const LoggedUser& user)
{
	if (isUserInRoom(user.getUsername()))
	{
				throw std::exception("User already in room");
	}
	m_users.push_back(user);
	m_roomData.currentPlayersAmount++;
}


/**
 * \brief Function will remove a user from the current room
 * \param user 
 */
void Room::removeUser(const LoggedUser& user)
{
	// if the user was not found then throw an exception
	if (!isUserInRoom(user.getUsername()))
	{
		throw std::exception("User not found");
	}

	for (int i = 0; i < m_users.size(); i++)
	{
		if (m_users[i].getUsername() == user.getUsername())
		{
			m_users.erase(m_users.begin() + i);
			break;
		}
	}


	m_roomData.currentPlayersAmount--;

	

}

/**
 * \brief Returns all of the current users in the room
 * \return the users in room
 */
std::vector<LoggedUser> Room::getAllUsers()
{
	return m_users;
}

std::vector<string> Room::getAllUsernames() const
{
	std::vector<string> usernames;
	for (const auto& user : m_users)
	{
		usernames.push_back(user.getUsername());
	}
	return usernames;
}

/**
 * \brief Returns the current RoomData
 * \return The roomdata
 */
RoomData Room::getRoomData() const
{
	return m_roomData;
}

/**
 * \brief Function checks if the given username is already in this room
 * \param username the username to check
 * \return True or False
 */
bool Room::isUserInRoom(const string& username)
{
	for (const auto& loggedUser : m_users)
	{
		if (loggedUser.getUsername() == username)
		{
			return true;
		}
	}

	return false;
}






