#pragma once


#include <vector>

using std::vector;

#include "LoggedUser.h"

struct RoomData
{
	unsigned int id;
	string name;
	unsigned int maxPlayers;
	unsigned int numOfQuestionsInGame;
	unsigned int timePerQuestion;
	unsigned int isActive;
	unsigned int currentPlayersAmount;
};

enum RoomStates
{
	WAITING = 1,
	IN_GAME = 2
};



class Room
{
public:

	Room(const RoomData& metadata);

	void addUser(const LoggedUser& user);
	void removeUser(const LoggedUser& user);
	std::vector<LoggedUser> getAllUsers();
	RoomData getRoomData() const;
	bool isUserInRoom(const string& username);
	void startGame();

private:
	vector<LoggedUser> m_users;
	RoomData m_roomData;
};

