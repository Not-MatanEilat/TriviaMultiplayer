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
	string sqlStatement = "SELECT * FROM users WHERE username = '" + username + "'";
	Result result = _db.exec(sqlStatement);
	if (result.empty())
	{
		return 0;
	}
	return 1;
}


