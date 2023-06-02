#pragma once

#include "Game.h"
#include "IDataBase.h"
#include "Room.h"


class GameManager
{

public:

	Game createGame(const Room& room);
	void deleteGame(unsigned int gameId);

	vector<string> getGamesResults(unsigned int gameId);

private:

	IDataBase* m_dataBase;
	vector<Game> m_games;
};

