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

/**
 * \brief The function will login the given user to the database, throws
 * an excetion if the user doesn't exists, also adds the user to the list of logged users
 * \param username the username to login
 * \param password the password to login
 */
void LoginManager::login(string const& username, string const& password)
{
	if (!m_database->doesUserExist(username))
	{
		throw std::exception("User doesn't exist");
	}

	if (!m_database->doesPasswordMatch(username, password))
	{
		throw std::exception("Password is incorrect");

	}

	// add the user to the logged users
	LoggedUser const user(username);
	m_loggedUsers.push_back(user);
}


