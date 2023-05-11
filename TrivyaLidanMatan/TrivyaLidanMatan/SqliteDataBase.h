#pragma once

#include "IDataBase.h"
#include "Sqlite3DB.h"


class SqliteDataBase : public IDataBase
{
public:
	bool open() override;
	bool close() override;
	int doesUserExist(string const username) override;

private:
	Sqlite3DB _db;

};

