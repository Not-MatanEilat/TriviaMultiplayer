#include "Matchmaker.h"

/**
 * \brief The constructor for the Matchmaker class.
 * \param playersPerGame amount of players per game
 * \param roomManager ref from room manager
 */
Matchmaker::Matchmaker(int playersPerGame, RoomManager& roomManager) : m_playersPerGame(playersPerGame), m_roomManager(roomManager)
{
	
}

/**
 * \brief Will add a player to the waiting players queue, if already in it, then throws exception
 * \param loggedUser the loggedUser to add
 */
void Matchmaker::addPlayer(const LoggedUser& loggedUser)
{
	if (isPlayerInQueue(loggedUser))
	{
		throw std::exception("Player is already in queue");
	}

	m_waitingPlayers.push(loggedUser);
}

/**
 * \brief Checks if player is already waiting in the queue
 * \param loggedUser the loggedUser to check
 * \return True or False
 */
bool Matchmaker::isPlayerInQueue(const LoggedUser& loggedUser)
{
	queue<LoggedUser> helper;

	bool playerInQueue = false;

	
	while (!m_waitingPlayers.empty())
	{
		if (m_waitingPlayers.front().getUsername() == loggedUser.getUsername())
		{
			playerInQueue = true;
		}

		helper.push(m_waitingPlayers.front());
		m_waitingPlayers.pop();
	}

	while (!helper.empty())
	{
		m_waitingPlayers.push(helper.front());
		helper.pop();
	}

	return playerInQueue;
}

/**
 * \brief Removes given loggedUser from the waiting queue, if not in it, throws an exception
 * \param loggedUser the loggedUser to remove
 */
void Matchmaker::removePlayer(const LoggedUser& loggedUser)
{
	if (!isPlayerInQueue(loggedUser))
	{
		throw std::exception("Player is not in queue");
	}

	queue<LoggedUser> helper;
	while (!m_waitingPlayers.empty())
	{
		if (m_waitingPlayers.front().getUsername() != loggedUser.getUsername())
		{
			helper.push(m_waitingPlayers.front());
		}
		m_waitingPlayers.pop();
	}

	while (!helper.empty())
	{
		m_waitingPlayers.push(helper.front());
		helper.pop();
	}
}



