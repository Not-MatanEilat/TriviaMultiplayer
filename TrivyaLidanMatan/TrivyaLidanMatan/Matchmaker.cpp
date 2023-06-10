#include "Matchmaker.h"

/**
 * \brief The constructor for the Matchmaker class.
 * \param playersPerGame amount of players per game
 * \param roomManager ref from room manager
 */
Matchmaker::Matchmaker(int playersPerGame, RoomManager& roomManager) : m_playersPerGame(playersPerGame), m_roomManager(roomManager)
{
	
}

