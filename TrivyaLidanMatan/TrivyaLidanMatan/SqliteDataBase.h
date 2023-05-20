#pragma once

#include "IDataBase.h"
#include "Sqlite3DB.h"

class IDataBase;

class SqliteDataBase : public IDataBase
{
public:

	SqliteDataBase();

	bool open() override;
	bool close() override;
	int doesUserExist(const string &username) override;
	int doesPasswordMatch(const string& username, const string& password) override;
	int addNewUser(const string& username, const string& password, const string& email) override;
	std::vector<string> getHighScores() override;
	std::vector<Question> getQuestions(int questionsNo) override;
	int getPlayerAverageAnswerTime(string const& username) override;
	int getNumOfCorrectAnswers(string const& username) override;
	int getNumOfTotalAnswers(string const& username) override;
	int getNumOfPlayerGames(string const& username) override;
	int getPlayerScore(string const& username) override;
private:
	Row getPlayerStatistics(string const& username);

private:
	Sqlite3DB _db;

};

