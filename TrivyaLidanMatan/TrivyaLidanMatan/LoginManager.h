#pragma once

#include "SqliteDataBase.h"
#include "LoggedUser.h"


class LoginManager
{
public:
	void signUp(string const &username, string const& password, string const& email);
	void login(string const& username, string const& password);
	void logout(string const& username);

private:
	IDataBase* m_database;
	vector<L
};
