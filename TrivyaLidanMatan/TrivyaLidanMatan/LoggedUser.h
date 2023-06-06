#pragma once

#include <string>


using std::string;


class LoggedUser
{
public:
	LoggedUser(const string &username);
	string getUsername() const;

	friend bool operator<(const LoggedUser& lhs, const LoggedUser& rhs);

private:
	string m_username;
};

