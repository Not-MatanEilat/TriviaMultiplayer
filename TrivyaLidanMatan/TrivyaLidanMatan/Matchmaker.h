#pragma once


#include <queue>
using std::queue;

#include "LoggedUser.h"
#include "RoomManager.h"
#include "GameManager.h"

class Matchmaker
{
public:
	Matchmaker(int playersPerGame, int questionsAmount, int questionTime, RoomManager& roomManager, GameManager& gameManager);

	void handleMatchmaking();
	void addPlayer(const LoggedUser& loggedUser);
	void removePlayer(const LoggedUser& loggedUser);

	bool isPlayerInQueue(const LoggedUser& loggedUser);

private:
	int m_playersPerGame;
	int m_questionsAmount;
	int m_questionTime;
	queue<LoggedUser> m_waitingPlayers;
	RoomManager& m_roomManager;
	GameManager& m_gameManager;
	
};
