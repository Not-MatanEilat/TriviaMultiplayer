#include "Game.h"

/**
 * \brief c'tor for game
 * \param questions questions of the game
 * \param players players of the game
 * \param gameId id of the game
 */
Game::Game(const vector<Question>& questions, const map<LoggedUser, GameData>& players, unsigned gameId): m_questions(questions),m_players(players),m_gameId(gameId)
{
}

/**
 * \brief returns the question for the user
 * \param loggedUser the user
 * \return the question
 */
Question Game::getQuestionForUser(const LoggedUser& loggedUser)
{
	GameData gameData = m_players[loggedUser];
	return gameData.currentQuestion;
}

/**
 * \brief submits the answer of the user
 * \param loggedUser user
 * \param answerId answer id
 */
void Game::submitAnswer(const LoggedUser& loggedUser, unsigned answerId)
{
	GameData gameData = m_players[loggedUser];
	if (answerId == gameData.currentQuestion.getCorrectAnswerId())
	{
		gameData.correctAnswerCount++;
	}
	else
	{
		gameData.wrongAnswerCount++;
	}
	
}

/**
 * \brief remove the user from the game and throws exception if the user is not in the game
 * \param loggedUser the user
 */
void Game::removePlayer(const LoggedUser& loggedUser)
{
	for (auto it = m_players.begin(); it != m_players.end(); it++)
	{
		if (it->first.getUsername() == loggedUser.getUsername())
		{
			m_players.erase(it);
			return;
		}
	}
	throw std::exception("Player not found");
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
 * \param loggedUser the user
 * \return true if the game is over otherwise false
 */
bool Game::isGameOver(const LoggedUser& loggedUser)
{
	if (amountOfQuestionsLeft(loggedUser) == 0)
	{
		return true;
	}
	return false;
}

/**
 * \brief returns players in the game
 * \return the map of players
 */
map<LoggedUser, GameData> Game::getPlayers() const
{
	return m_players;
}

/**
 * \brief returns the amount of questions left
 * \param loggedUser the user
 * \return the amount of questions left
 */
int Game::amountOfQuestionsLeft(const LoggedUser& loggedUser)
{
	GameData gameData = m_players[loggedUser];
	int questionCount = m_questions.size();
	int totalAnswerCount = gameData.correctAnswerCount + gameData.wrongAnswerCount;
	return questionCount - totalAnswerCount;
}
