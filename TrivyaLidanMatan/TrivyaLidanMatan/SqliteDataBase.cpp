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

