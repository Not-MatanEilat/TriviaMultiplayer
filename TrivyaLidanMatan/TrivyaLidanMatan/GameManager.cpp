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
Game GameManager::createGame(Room& room)
{
	vector<LoggedUser> users = room.getAllUsers();
	map<LoggedUser, GameData> players;
	for (LoggedUser user : users)
	{
		GameData emptyData;
		emptyData.correctAnswerCount = 0;
		emptyData.wrongAnswerCount = 0;
		emptyData.averageAnswerTime = 0;
		emptyData.currentQuestion = nullptr;
		players.insert({ user, emptyData });
	}
	vector<Question> questions = m_dataBase->getQuestions(room.getRoomData().numOfQuestionsInGame);
	Game game(questions, players, getLastID() + 1);
	return game;
}

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
