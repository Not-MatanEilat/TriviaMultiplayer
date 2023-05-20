#include "StatisticsManager.h"

StatisticsManager::StatisticsManager(IDataBase* mDatabase): m_database(mDatabase)
{
}

std::vector<string> StatisticsManager::getHighScore()
{
	return m_database->getHighScores();
}

std::vector<string> StatisticsManager::getUserStatistics(const string& username)
{
	return {};
}
