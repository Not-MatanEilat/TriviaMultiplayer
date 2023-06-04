#include "GameManager.h"

/**
 * \brief c'tor for GameManager
 * \param dataBase the database
 */
GameManager::GameManager(IDataBase* dataBase): m_dataBase(dataBase)
{
}

/**
 * \brief creates a game from a room
 * \param room room to create game from
 * \return the created game
 */
Game GameManager::createGame(Room& room)
{
	vector<LoggedUser> users = room.getAllUsers();
	map<LoggedUser, GameData> players;
	for (LoggedUser user : users)
	{
		GameData emptyData;
		emptyData.correctAnswerCount = 0;
		emptyData.wrongAnswerCount = 0;
		emptyData.averageAnswerTime = 0;
		emptyData.currentQuestion = nullptr;
		players.insert({ user, emptyData });
	}
	vector<Question> questions = m_dataBase->getQuestions(room.getRoomData().numOfQuestionsInGame);
	Game game(questions, players, getLastID() + 1);
	return game;
}

/**
 * \brief delete a game by id
 * \param gameId id of the game
 */
void GameManager::deleteGame(unsigned gameId)
{
	for (auto it = m_games.begin(); it != m_games.end(); it++)
	{
		if (it->getGameId() == gameId)
		{
			m_games.erase(it);
			return;
		}
	}
	throw std::exception("Game not found");
}

vector<string> GameManager::getGamesResults(unsigned gameId)
{
	Game& game = getGame(gameId);
	vector<string> results;
	for (auto it = game.getPlayers().begin(); it != game.getPlayers().end(); it++)
	{
		std::stringstream ss;
		ss << it->first.getUsername() << " " << it->second.correctAnswerCount << " " << it->second.wrongAnswerCount << " " << it->second.averageAnswerTime << "\n";
		results.push_back(ss.str());
	}
	return results;
}

/**
 * \brief returns the last id
 * \return the last id
 */
int GameManager::getLastID()
{
	int max = 0;
	for (Game game : m_games)
	{
		if (game.getGameId() > max)
		{
			max = game.getGameId();
		}
	}
	return max;
}

/**
 * \brief returns the game by id
 * \param gameId id of the game
 * \return the game with id
 */
Game& GameManager::getGame(unsigned gameId)
{
	for (Game& game : m_games)
	{
		if (game.getGameId() == gameId)
		{
			return game;
		}
	}
	throw std::exception("Game not found");
}

Game& GameManager::getGame(LoggedUser user)
{
	for (Game& game : m_games)
	{
		if (game.getPlayers().find(user) != game.getPlayers().end())
		{
			return game;
		}
	}
	throw std::exception("Game not found");
}
