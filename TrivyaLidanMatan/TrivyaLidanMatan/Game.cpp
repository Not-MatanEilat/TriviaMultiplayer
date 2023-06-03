#include "Game.h"

map<LoggedUser, GameData> Game::getPlayers() const
{
	return m_players;
}
