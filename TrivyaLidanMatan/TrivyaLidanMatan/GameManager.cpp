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
Game GameManager::createGame(Room room)
{
	vector<LoggedUser> users = room.getAllUsers();
	map<string, GameData> players;
	for (LoggedUser user : users)
	{
		players.insert({ user.getUsername(), GameData()});
	}
	vector<Question> questions = m_dataBase->getQuestions(room.getRoomData().numOfQuestionsInGame);
	Game game(questions, players, getLastID() + 1, m_dataBase);
	return game;
}

/**
 * \brief add the game
 * \param game the game
 * \return the game ref
 */
Game& GameManager::addGame(Game& game)
{
	m_games.push_back(game);
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

vector<PlayerResults> GameManager::getGamesResults(unsigned gameId)
{
	vector<PlayerResults> results;
	Game& game = getGame(gameId);
	for (const auto& player : game.getPlayers())
	{
		PlayerResults playerResults;

		string loggedUser = player.first;
		GameData gameData = player.second;


		playerResults.username = loggedUser;

		playerResults.correctAnswerCount = gameData.correctAnswerCount;
		playerResults.wrongAnswerCount = gameData.wrongAnswerCount;
		playerResults.averageAnswerTime = gameData.averageAnswerTime * 1000;

		results.push_back(playerResults);
	}
	std::sort(results.begin(), results.end(), [&](PlayerResults a, PlayerResults b) {return a.correctAnswerCount > b.averageAnswerTime; });

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
	throw std::exception("Game id not found");
}

Game& GameManager::getGame(LoggedUser user)
{
	for (Game& game : m_games)
	{
		if (game.isPlayerInGame(user))
		{
			return game;
		}
	}
	throw std::exception("Game not found for user");
}
