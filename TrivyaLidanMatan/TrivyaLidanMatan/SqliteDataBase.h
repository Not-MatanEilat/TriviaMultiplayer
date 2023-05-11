#pragma once

#include "IDataBase.h"
#include "Sqlite3DB.h"


class SqliteDataBase : public IDataBase
{
public:
	bool open() override;
	bool close() override;
	int doesUserExist(string const &username) override;
	int doesPasswordMatch(string const& username, string const& password) override;
	int addNewUser(string const& username, string const& password, string const& email) override;

private:
	Sqlite3DB _db;

};

