#include "LoginManager.h"

/**
* \brief Constructor for LoginManager, will also open the database
*/
LoginManager:: LoginManager()
{
	m_database = new SqliteDataBase();
	m_database->open();
}

/**
 * \brief The function will signUp the given user to the database, throws an excetion if the user already exists
 * \param username the username to signUp
 * \param password the password to signUp
 * \param email the email to signUp
 */
void LoginManager::signUp(string const& username, string const& password, string const& email) const
{
	// check if user exits already
	if (m_database->doesUserExist(username))
	{
		throw std::exception("User already exists");
	}
	m_database->addNewUser(username, password, email);
}

