#include "Matchmaker.h"

/**
 * \brief The constructor for the Matchmaker class.
 * \param playersPerGame amount of players per game
 * \param roomManager ref from room manager
 */
Matchmaker::Matchmaker(int playersPerGame, int questionsAmount, int questionTime, RoomManager& roomManager, GameManager& gameManager) : m_playersPerGame(playersPerGame), m_questionsAmount(questionsAmount), m_questionTime(questionTime), m_roomManager(roomManager), m_gameManager(gameManager)
{
	
}




void Matchmaker::handleMatchmaking()
{
	// if enough users in queue to make a new game here
	if (m_waitingPlayers.size() >= m_playersPerGame)
	{
		vector<LoggedUser> players;
		for (int i = 0; i < m_playersPerGame; i++)
		{
			players.push_back(m_waitingPlayers.front());
			m_waitingPlayers.pop();
		}

		RoomData roomData;

		roomData.id = m_roomManager.getNewRoomId();
		roomData.currentPlayersAmount = m_playersPerGame;
		roomData.maxPlayers = m_playersPerGame;
		roomData.isActive = true;
		roomData.numOfQuestionsInGame = m_questionsAmount;
		roomData.timePerQuestion = m_questionTime;

		m_roomManager.createRoom(roomData);

		for (const LoggedUser& loggedUser : players)
		{
			m_roomManager.getRoom(roomData.id).addUser(loggedUser);
		}

		m_gameManager.createGame(m_roomManager.getRoom(roomData.id));

	}

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



