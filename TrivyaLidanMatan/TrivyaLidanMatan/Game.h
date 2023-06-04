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
	Question getQuestionForUser(const LoggedUser& loggedUser);
	void submitAnswer(const LoggedUser& loggedUser, unsigned int answerId);
	void removePlayer(const LoggedUser& loggedUser);
	unsigned int getGameId() const;

	// this is not in the UML, but, a check for if the is game over is needed, so for now, it is here
	// I think the implementation should be something like m_questions.size() == 0
	// but I'm Not sure
	bool isGameOver(const LoggedUser& loggedUser);
	map<LoggedUser, GameData> getPlayers() const;
	int amountOfQuestionsLeft(const LoggedUser& loggedUser);

private:
	vector<Question> m_questions;
	map<LoggedUser, GameData> m_players;
	unsigned int m_gameId;
};

