#pragma once
#include "IDataBase.h"

class StatisticsManager
{
public:
	StatisticsManager(IDataBase* mDatabase);

	std::vector<string> getHighScore();
	std::vector<string> getUserStatistics(const string& username);

private:
	IDataBase* m_database;
};

