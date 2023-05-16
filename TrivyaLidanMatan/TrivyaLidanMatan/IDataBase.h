#pragma once

#define DB_PATH "Trivia.db"
#include <string>
#include <regex>


using std::regex;
using std::regex_search;

using std::string;

class IDataBase
{
public:
	virtual bool open() = 0;
	virtual bool close() = 0;
	virtual int doesUserExist(string const &username) = 0;
	virtual int doesPasswordMatch(string const &username, string const &password) = 0;
	virtual int addNewUser(string const &username, string const& password, string const &email) = 0;

	static bool isValidPassword(const string& username);
	static bool isValidEmail(const string& email);

};

