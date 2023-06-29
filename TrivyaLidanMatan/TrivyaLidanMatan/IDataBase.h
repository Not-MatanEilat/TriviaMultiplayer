#pragma once

#define DB_PATH "Trivia.db"
#include <string>
#include <regex>
#include "Question.h"
#include "Sqlite3DB.h"


using std::regex;
using std::regex_search;

using std::string;
using std::vector;

class Question;

class IDataBase
{
public:
	virtual bool open() = 0;
	virtual bool close() = 0;
	virtual int doesUserExist(string const &username) = 0;
	virtual int doesPasswordMatch(string const &username, string const &password) = 0;
	virtual int addNewUser(string const &username, string const& password, string const &email) = 0;
	
	virtual vector<Question> getQuestions(int questionsNo) = 0;
	virtual float getPlayerAverageAnswerTime(string const& username) = 0;
	virtual int getNumOfCorrectAnswers(string const& username) = 0;
	virtual int getNumOfTotalAnswers(string const& username) = 0;
	virtual int getNumOfPlayerGames(string const& username) = 0;
	virtual int getPlayerScore(string const& username) = 0;
	virtual vector<string> getHighScores() = 0;
	virtual void setPlayerStatistics(string const& username, Row stats) = 0;

	virtual void addQuestion(string const& question, string const& correctAns, string const& ans2, string const& ans3, string const& ans4) = 0;

	static bool isValidPassword(const string& username);
	static bool isValidEmail(const string& email);
	static bool isValidUsername(const string& username);

};

