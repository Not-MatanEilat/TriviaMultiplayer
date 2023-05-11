#include "SqliteDataBase.h"

bool SqliteDataBase::open()
{
	_db =  Sqlite3DB("trivia.db");
	return _db.isOpen();
}

