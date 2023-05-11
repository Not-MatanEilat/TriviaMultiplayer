#include "SqliteDataBase.h"

/**
 * \brief Will open the database
 * \return True or False, if the database opened
 */
bool SqliteDataBase::open()
{
	_db =  Sqlite3DB("Trivia.db");
	return _db.open();
}

/**
 * \brief Will close the database
 * \return True or False, if the database closed
 */
bool SqliteDataBase::close()
{
	return _db.close();
}

/**
 * \brief Function checks if the user exists in the database
 * \param username the username to check
 * \return 1 if the user exists, 0 if not
 */
int SqliteDataBase::doesUserExist(string const &username)
{
	string const sqlStatement = "SELECT * FROM users WHERE username = '" + username + "'";
	Result const result = _db.exec(sqlStatement);
	if (result.empty())
	{
		return 0;
	}
	return 1;
}

/**
 * \brief Function checks if the username given has the password given, returns bool for result
 * \param username the username to check the password for
 * \param password the password to check
 * \return True or False if the password matches the given username's password
 */
int SqliteDataBase::doesPasswordMatch(string const& username, string const& password)
{
	string const sqlStatement = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";
	Result const result = _db.exec(sqlStatement);
	if (result.empty())
	{
		return 0;
	}
	return 1;
}



