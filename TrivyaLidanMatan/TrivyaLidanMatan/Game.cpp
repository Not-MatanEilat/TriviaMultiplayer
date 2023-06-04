#include "Game.h"

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
