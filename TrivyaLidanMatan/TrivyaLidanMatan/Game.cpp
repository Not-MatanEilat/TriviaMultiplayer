#include "Game.h"

#include <ctime>

/**
 * \brief c'tor for game
 * \param questions questions of the game
 * \param players players of the game
 * \param gameId id of the game
 */
Game::Game(vector<Question> questions, const map<string, GameData>& players, unsigned gameId,	  IDataBase* database): m_questions(questions),m_players(players),m_gameId(gameId), m_database(database)
{
}

/**
 * \brief returns the question for the user
 * \param loggedUser the user
 * \return the question
 */
Question* Game::getQuestionForUser(const LoggedUser& loggedUser)
{
	GameData& gameData = m_players[loggedUser.getUsername()];
	int totalAnswerCount = gameData.correctAnswerCount + gameData.wrongAnswerCount;
	if (isGameOver(loggedUser.getUsername()))
	{
		throw std::exception("no more questions for you");
	}
	gameData.lastAnswerTime = (float)clock() / CLOCKS_PER_SEC;
	gameData.currentQuestion = &(m_questions[totalAnswerCount]);
	return gameData.currentQuestion;
}

/**
 * \brief submits the answer of the user
 * \param loggedUser user
 * \param answerId answer id
 */
bool Game::submitAnswer(const LoggedUser& loggedUser, unsigned answerId)
{
	GameData& gameData = m_players[loggedUser.getUsername()];

	if (isGameOver(loggedUser.getUsername()))
	{
		throw std::exception("no more questions for you");
	}
	float diff = (float)clock() / CLOCKS_PER_SEC - gameData.lastAnswerTime;
	gameData.averageAnswerTime = (gameData.averageAnswerTime + diff) / 2;
	if (answerId == gameData.currentQuestion->getCorrectAnswerId())
	{
		gameData.correctAnswerCount++;
		return true;
	}
	else
	{
		gameData.wrongAnswerCount++;
		return false;
	}
	
}

/**
 * \brief remove the user from the game and throws exception if the user is not in the game
 * \param loggedUser the user
 */
void Game::removePlayer(const LoggedUser& loggedUser)
{
	GameData& gameData = m_players[loggedUser.getUsername()];
	Row stats;
	stats["averageAnswerTime"] = std::to_string((m_database->getPlayerAverageAnswerTime(loggedUser.getUsername()) + gameData.averageAnswerTime) / 2);
	stats["correctAnswers"] = std::to_string(m_database->getNumOfCorrectAnswers(loggedUser.getUsername()) + gameData.correctAnswerCount);
	stats["totalAnswers"] = std::to_string(m_database->getNumOfTotalAnswers(loggedUser.getUsername()) + gameData.wrongAnswerCount + gameData.correctAnswerCount);
	stats["games"] = std::to_string(m_database->getNumOfPlayerGames(loggedUser.getUsername()) + 1);
	m_database->setPlayerStatistics(loggedUser.getUsername(), stats);

	m_players.erase(loggedUser.getUsername());
}

/**
 * \brief returns the id of the game
 * \return game id
 */
unsigned Game::getGameId() const
{
	return m_gameId;
}

/**
 * \brief return if the game is over
 * \param username the username
 * \return true if the game is over otherwise false
 */
bool Game::isGameOver(const string& username)
{
	return amountOfQuestionsLeft(username) <= 0;
}

/**
 * \brief return if game is over for all the players
 * \return True or False
 */
bool Game::isGameOver()
{
	for (auto& player : m_players)
	{
		if (!isGameOver(player.first))
		{
			return false;
		}
	}
	return true;
}


/**
 * \brief returns players in the game
 * \return the map of players
 */
map<string, GameData> Game::getPlayers() const
{
	return m_players;
}

/**
 * \brief returns the amount of questions left
 * \param username the username
 * \return the amount of questions left
 */
int Game::amountOfQuestionsLeft(const string& username)
{
	GameData& gameData = m_players[username];
	int questionCount = m_questions.size();
	int totalAnswerCount = gameData.correctAnswerCount + gameData.wrongAnswerCount;
	return questionCount - totalAnswerCount;
}

/**
 * \brief check if player in game
 * \param loggedUser the user
 * \return true if player in game
 */
bool Game::isPlayerInGame(const LoggedUser& loggedUser) const
{
	for (std::pair<const string, GameData> pair : m_players)
	{
		if (pair.first == loggedUser.getUsername())
		{
			return true;
		}
	}
	return false;
}
