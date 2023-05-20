#include "StatisticsManager.h"

/**
 * \brief ctor for StatisticsManager
 * \param mDatabase the database
 */
StatisticsManager::StatisticsManager(IDataBase* mDatabase): m_database(mDatabase)
{
}

/**
 * \brief get the high scores from the database
 * \return the high scores
 */
std::vector<string> StatisticsManager::getHighScore()
{
	return m_database->getHighScores();
}

/**
 * \brief get user statistics
 * \param username username
 * \return the user statistics
 */
std::vector<string> StatisticsManager::getUserStatistics(const string& username)
{
	std::vector<string> userStatistics;
	userStatistics.push_back("Average answer time: " + std::to_string(m_database->getPlayerAverageAnswerTime(username)));
	userStatistics.push_back("Correct answers: " + std::to_string(m_database->getNumOfCorrectAnswers(username)));
	userStatistics.push_back("Total answers: " + std::to_string(m_database->getNumOfTotalAnswers(username)));
	userStatistics.push_back("Games: " + std::to_string(m_database->getNumOfPlayerGames(username)));
	userStatistics.push_back("Score: " + std::to_string(m_database->getPlayerScore(username)));
	return userStatistics;
}
