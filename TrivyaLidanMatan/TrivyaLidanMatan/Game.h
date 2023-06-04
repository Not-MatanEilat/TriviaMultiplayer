#pragma once

#include <map>
#include <vector>

#include "Question.h"

#include "LoggedUser.h"



using std::map;
using std::vector;

typedef struct GameData
{
	Question currentQuestion;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	float averageAnswerTime;
} GameData;


class Game
{
public:
	Game(const vector<Question>& questions, const map<LoggedUser, GameData>& players, unsigned gameId);

	Question getQuestionForUser(const LoggedUser& loggedUser);
	void submitAnswer(const LoggedUser& loggedUser, unsigned int answerId);
	void removePlayer(const LoggedUser& loggedUser);
	unsigned int getGameId() const;

	bool isGameOver(const LoggedUser& loggedUser);
	map<LoggedUser, GameData> getPlayers() const;
	int amountOfQuestionsLeft(const LoggedUser& loggedUser);

private:
	vector<Question> m_questions;
	map<LoggedUser, GameData> m_players;
	unsigned int m_gameId;
};

