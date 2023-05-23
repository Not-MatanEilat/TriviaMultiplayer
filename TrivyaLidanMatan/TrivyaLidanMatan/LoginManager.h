#pragma once

#include "SqliteDataBase.h"
#include "LoggedUser.h"

class MenuRequestHandler;

class LoginManager
{
public:

	LoginManager(IDataBase* database);

	void signUp(const string& username, const string& password, const string& email);
	void login(const string& username, const string& password);
	void logout(const string& username);

	LoggedUser getLoggedUser(const string& username) const;

private:

	IDataBase* m_database;
	vector<LoggedUser> m_loggedUsers;
};
