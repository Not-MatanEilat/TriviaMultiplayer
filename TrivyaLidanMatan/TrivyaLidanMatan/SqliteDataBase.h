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
	int doesUserExist(const string &username) override;
	int doesPasswordMatch(const string& username, const string& password) override;
	int addNewUser(const string& username, const string& password, const string& email) override;

private:
	Sqlite3DB _db;

};

