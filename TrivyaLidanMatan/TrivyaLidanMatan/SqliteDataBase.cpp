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
	string const sqlStatement = "SELECT * FROM users WHERE username = '$0'";
	vector<string> params = {username};
	Result const result = _db.exec(sqlStatement,  params);
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
	string const sqlStatement = "SELECT * FROM users WHERE username = '$0' AND password = '$1'";
	vector<string> params = { username, password };
	Result const result = _db.exec(sqlStatement, params);
	if (result.empty())
	{
		return 0;
	}
	return 1;
}

/**
 * \brief Function adds a new user to the database
 * \param username the username to add
 * \param password the password to add
 * \param email the email to add
 * \return 1 or 0, depends on if the user was added, 1 for true, 0 for a false
 */
int SqliteDataBase::addNewUser(string const& username, string const& password, string const& email)
{
	string const sqlStatement = "INSERT INTO users (username, password, email) VALUES ('$0', '$1', '$2')";
	vector<string> params = { username, password, email };
	_db.exec(sqlStatement, params);

	// check if the given user was successfully added
	string const sqlStatement2 = "SELECT * FROM users WHERE username = '$0' AND password = '$1' AND email = '$2' ";
	params = { username, password, email };
	Result const result = _db.exec(sqlStatement2, params);

	// if the list is empty and we didn't find the user, it means the user wasn't added, so return 0 here
	if (result.empty())
	{
		return 0;
	}

	return 1;
}




