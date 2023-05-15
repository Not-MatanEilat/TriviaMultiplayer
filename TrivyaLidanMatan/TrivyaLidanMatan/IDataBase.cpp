#include "IDataBase.h"

/**
* \brief Checks if the username is valid
* \param username the username to check
* \return true if the username is valid, false otherwise
*/
bool IDataBase::isValidPassword(const string& username)
{
	// Password must be exactly 8 characters long
	if (username.length() != 8)
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
