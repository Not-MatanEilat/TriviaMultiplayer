#pragma once
#include "IDataBase.h"

#define MAX_HIGHSCORES 5

class StatisticsManager
{
public:
	StatisticsManager(IDataBase* mDatabase);

	std::vector<string> getHighScore();
	std::vector<string> getUserStatistics(const string& username);

private:
	IDataBase* m_database;
};

