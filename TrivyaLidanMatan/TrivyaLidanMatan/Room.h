#pragma once


#include <vector>
s

#include "LoggedUser.h"

struct RoomData
{
	unsigned int id;
	string name;
	unsigned int maxPlayers;
	unsigned int numOfQuestionsInGame;
	unsigned int timePerQuestion;
	unsigned int isActive;
};



class Room
{
public:
	void addUser(LoggedUser user);
	void removeUser(LoggedUser user);
	std::vector<LoggedUser> getAllUsers();

private:
	vector<LoggedUser> m_users;
	RoomData m_metadata;
};

