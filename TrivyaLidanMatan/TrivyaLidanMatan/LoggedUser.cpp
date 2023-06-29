#include "LoggedUser.h"

/**
 * \brief C'tor for LoggedUser
 * \param username the username to set
 */
LoggedUser::LoggedUser(const string &username): m_username(username)
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

/**
 * \brief operator < for LoggedUser
 * \param lhs left side
 * \param rhs right side
 * \return true if left smaller than right
 */
bool operator<(const LoggedUser& lhs, const LoggedUser& rhs)
{
	return lhs.m_username < rhs.m_username;
}
