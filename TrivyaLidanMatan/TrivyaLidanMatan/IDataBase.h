#pragma once
class IDataBase
{
public:
	virtual bool open() = 0;
	virtual bool close() = 0;
	virtual int doesUserExist(string const &username) = 0;
	virtual int doesPasswordMatch(string const &username, string const &password) = 0;
	virtual int addNewUser(string const &username, string const& password, string const &email) = 0;



};

