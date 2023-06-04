#pragma once

#include "Game.h"
#include "IDataBase.h"
#include "Room.h"
#include <sstream>


class GameManager
{

public:
	GameManager(IDataBase* dataBase);

	Game createGame(Room& room);
	Game& addGame(Game& game);
	void deleteGame(unsigned int gameId);

	vector<string> getGamesResults(unsigned int gameId);
	Game& getGame(unsigned int gameId);
	Game& getGame(LoggedUser user);

private:
	IDataBase* m_dataBase;
	vector<Game> m_games;

	int getLastID();
	
};

