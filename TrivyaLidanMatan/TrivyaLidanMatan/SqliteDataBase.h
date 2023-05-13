#pragma once

#include "IDataBase.h"
#include "Sqlite3DB.h"

class IDataBase;

class SqliteDataBase : public IDataBase
{
public:

	SqliteDataBase();

	bool open() override;
	bool close() override;
	int doesUserExist(string const &username) override;
	int doesPasswordMatch(string const& username, string const& password) override;
	int addNewUser(string const& username, string const& password, string const& email) override;

private:
	Sqlite3DB _db;

};

