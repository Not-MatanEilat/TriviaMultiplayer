#pragma once

#include "SqliteDataBase.h"
#include "LoggedUser.h"

class MenuRequestHandler;

class LoginManager
{
public:

	LoginManager(IDataBase* database);

	void signUp(string const &username, string const& password, string const& email) const;
	void login(string const& username, string const& password);
	void logout(string const& username);

private:

	IDataBase* m_database;
	vector<LoggedUser> m_loggedUsers;
};
