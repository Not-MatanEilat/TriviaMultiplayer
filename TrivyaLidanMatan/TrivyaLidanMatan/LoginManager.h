#pragma once

#include "SqliteDataBase.h"
#include "LoggedUser.h"


class LoginManager
{
public:

	LoginManager();

	void signUp(string const &username, string const& password, string const& email) const;
	void login(string const& username, string const& password);
	void logout(string const& username);

private:

	bool isUserLoggedIn(string const& username) const;

	IDataBase* m_database;
	vector<LoggedUser> m_loggedUsers;
};
