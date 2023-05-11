#pragma once

#include <string>


using std::string;


class LoggedUser
{
public:
	LoggedUser(string const &username);
	string getUsername() const;


private:
	string m_username;
};

