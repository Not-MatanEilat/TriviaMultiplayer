#include "LoginManager.h"

/**
* \brief Constructor for LoginManager
*/
LoginManager::LoginManager(IDataBase* database) : m_database(database)
{
	
}

/**
 * \brief The function will signUp the given user to the database, throws an excetion if the user already exists
 * \param username the username to signUp
 * \param password the password to signUp
 * \param email the email to signUp	
 */
void LoginManager::signUp(const string& username, const string& password, const string& email)
{
	// check if user exits already
	if (m_database->doesUserExist(username))
	{
		throw std::exception("User already exists");
	}
	// check if password valid
	if (!m_database->isValidPassword(password))
	{
		throw std::exception("Password is invalid");
	}
	if (!m_database->isValidEmail(email))
	{
		throw std::exception("Email is invalid");
	}
	m_database->addNewUser(username, password, email);
	login(username, password);
}

/**
 * \brief The function will login the given user to the database, throws
 * an exception if the user doesn't exists, also adds the user to the list of logged users
 * \param username the username to login
 * \param password the password to login
 */
void LoginManager::login(const string& username, const string& password)
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

/**
 * \brief Will logout the give user, throws an exception if the user isn't logged in
 * \param username the username to logout
 */
void LoginManager::logout(const string& username)
{
	bool isUserFound = false;

	for (int i = 0; i < m_loggedUsers.size(); i++)
	{
		if (m_loggedUsers[i].getUsername() == username)
		{
			m_loggedUsers.erase(m_loggedUsers.begin() + i);
			isUserFound = true;
		}
	}

	if (!isUserFound)
	{
		throw std::exception("User isn't logged in");
	}
}

/**
 * \brief Function returns the logged user that was needed
 * \param username the username to get logged user of
 * \return Loggeduser of the given username string
 */
LoggedUser LoginManager::getLoggedUser(const string& username) const
{
	for (int i = 0; i < m_loggedUsers.size(); i++)
	{
		if (m_loggedUsers[i].getUsername() == username)
		{
			return m_loggedUsers[i];
		}
	}
	throw std::exception("User isn't logged in");
}





