#include "IDataBase.h"

/**
* \brief Checks if the username is valid
* \param username the username to check
* \return true if the username is valid, false otherwise
*/
bool IDataBase::isValidPassword(const string& username)
{
	// Password must be at least 8 characters long
	if (username.length() < 8)
	{
		return false;
	}
	// Password must contain at least one digit
	if (!regex_search(username, regex(".*[0-9].*")))
	{
		return false;
	}
	// Password must contain at least one letter
	if (!regex_search(username, regex(".*[a-zA-Z].*")))
	{
		return false;
	}
	if (!regex_search(username, regex(".*[!@#$%^&*].*")))
	{
		return false;
	}
	return true;
}

/**
 * \brief Checks if the email is valid
 * \param email the email to check
 * \return true if the email is valid, false otherwise
 */
bool IDataBase::isValidEmail(const string& email)
{
	// Check if email is valid
	// Gmail has to have NAME@something.something(2 - 3 chars)
	if (!regex_search(email, regex("[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$")))
	{
		return false;
	}
	return true;
}

