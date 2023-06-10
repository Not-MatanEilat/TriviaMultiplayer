#pragma once


#include <queue>
using std::queue;

#include "LoggedUser.h"
#include "RoomManager.h"

class Matchmaker
{
public:
	Matchmaker(int playersPerGame, RoomManager& roomManager);

	void handleMatchmaking();
	void addPlayer(const LoggedUser& loggedUser);
	void removePlayer(const LoggedUser& loggedUser);

	bool isPlayerInQueue(const LoggedUser& loggedUser);

private:
	int m_playersPerGame;
	queue<LoggedUser> m_waitingPlayers;
	RoomManager& m_roomManager;
	
};
