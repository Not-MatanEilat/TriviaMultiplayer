#pragma once

#include "IDataBase.h"
#include "Sqlite3DB.h"
#include <algorithm>

#define MAX_QUESTION_CHARS 100
#define MAX_ANSWER_CHARS 50

class IDataBase;

class SqliteDataBase : public IDataBase
{
public:

	SqliteDataBase();
	virtual ~SqliteDataBase();

	bool open() override;
	bool close() override;
	int doesUserExist(const string &username) override;
	int doesPasswordMatch(const string& username, const string& password) override;
	int addNewUser(const string& username, const string& password, const string& email) override;
	std::vector<string> getUsers();
	bool compareScoresByUserName(string& user1, string& user2);
	std::vector<string> getHighScores() override;
	std::vector<Question> getQuestions(int questionsNo) override;
	float getPlayerAverageAnswerTime(string const& username) override;
	int getNumOfCorrectAnswers(string const& username) override;
	int getNumOfTotalAnswers(string const& username) override;
	int getNumOfPlayerGames(string const& username) override;
	int getPlayerScore(string const& username) override;
	void setPlayerStatistics(string const& username, Row stats) override;
	void addQuestion(string const& question, string const& correctAns, string const& ans2, string const& ans3, string const& ans4) override;
	string getSecurityKey(string encryptedText) override;
	void setSecurityKey(string encryptedText, string key, string type) override;
private:
	Row getPlayerStatistics(string const& username);
	

private:
	Sqlite3DB _db;

};

