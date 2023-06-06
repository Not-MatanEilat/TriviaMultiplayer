#pragma once

#include "Game.h"
#include "IDataBase.h"
#include "Room.h"
#include <sstream>

#include "JsonResponsePacketSerializer.h"

struct PlayerResults;

class GameManager
{

public:
	GameManager(IDataBase* dataBase);

	Game createGame(Room room);
	Game& addGame(Game& game);
	void deleteGame(unsigned int gameId);

	vector<PlayerResults> getGamesResults(unsigned int gameId);
	Game& getGame(unsigned int gameId);
	Game& getGame(LoggedUser user);

private:
	IDataBase* m_dataBase;
	vector<Game> m_games;

	int getLastID();
	
};

