#include "Game.h"

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
 * \brief returns the id of the game
 * \return game id
 */
unsigned Game::getGameId() const
{
	return m_gameId;
}

/**
 * \brief returns players in the game
 * \return the map of players
 */
map<LoggedUser, GameData> Game::getPlayers() const
{
	return m_players;
}
