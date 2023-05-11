#include "LoggedUser.h"

/**
 * \brief C'tor for LoggedUser
 * \param username the username to set
 */
LoggedUser::LoggedUser(string const &username): m_username(username)
{
	
}

/**
 * \brief Returns the username of the user
 * \return username as the string
 */
string LoggedUser::getUsername() const
{
	return m_username;
}


