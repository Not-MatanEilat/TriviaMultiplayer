#include "LoginManager.h"

LoginManager:: LoginManager()
{
	m_database = new SqliteDataBase;
	m_database->open();
}
