#include "LoginManager.h"

/**
* \brief Constructor for LoginManager, will also open the database
*/
LoginManager:: LoginManager()
{
	m_database = new SqliteDataBase();
	m_database->open();
}
