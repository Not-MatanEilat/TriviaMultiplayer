#pragma once

#define DB_PATH "Trivia.db"
#include <string>
#include <regex>


using std::regex;
using std::regex_search;

using std::string;
using std::vector;

typedef struct Question
{
	string question;
	string correctAnswer;
	vector<string> incorrectAnswers;

} Question;

class IDataBase
{
public:
	virtual bool open() = 0;
	virtual bool close() = 0;
	virtual int doesUserExist(string const &username) = 0;
	virtual int doesPasswordMatch(string const &username, string const &password) = 0;
	virtual int addNewUser(string const &username, string const& password, string const &email) = 0;
	
	virtual vector<Question> getQuestions(int questionsNo) = 0;
	virtual int getPlayerAverageAnswerTime(string const& username) = 0;
	virtual int getNumOfCorrectAnswers(string const& username) = 0;
	virtual int getNumOfTotalAnswers(string const& username) = 0;
	virtual int getNumOfPlayerGames(string const& username) = 0;
	virtual int getPlayerScore(string const& username) = 0;
	virtual vector<string> getHighScores() = 0;

	static bool isValidPassword(const string& username);
	static bool isValidEmail(const string& email);

};

