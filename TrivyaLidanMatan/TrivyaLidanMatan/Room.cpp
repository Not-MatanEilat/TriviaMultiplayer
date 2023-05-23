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
	for (const auto& loggedUser : m_users)
	{
		if (loggedUser.getUsername() == user.getUsername())
		{
			throw std::exception("User already in room");
		}
	}
	m_users.push_back(user);
}

/**
 * \brief Function will remove a user from the current room
 * \param user 
 */
void Room::removeUser(const LoggedUser& user)
{
	bool isUserFound = false;
	for (int i = 0; i < m_users.size(); i++)
	{
		if (m_users[i].getUsername() == user.getUsername())
		{
			m_users.erase(m_users.begin() + i);
			isUserFound = true;
			break;
		}
	}

	// if the user was not found then throw an exception
	if (!isUserFound)
	{
		throw std::exception("User not found");
	}

	

}

/**
 * \brief Returns all of the current users in the room
 * \return the users in room
 */
std::vector<LoggedUser> Room::getAllUsers()
{
	return m_users;
}

/**
 * \brief Returns the current RoomData
 * \return The roomdata
 */
RoomData Room::getRoomData() const
{
	return m_roomData;
}





