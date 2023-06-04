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
 * \brief returns players in the game
 * \return the map of players
 */
map<LoggedUser, GameData> Game::getPlayers() const
{
	return m_players;
}
