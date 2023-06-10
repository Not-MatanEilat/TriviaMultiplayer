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
	void addPlayer(LoggedUser loggedUser);
	void removePlayer(LoggedUser loggedUser);

private:
	int m_playersPerGame;
	queue<LoggedUser> m_waitingPlayers;
	RoomManager& m_roomManager;
	
};
