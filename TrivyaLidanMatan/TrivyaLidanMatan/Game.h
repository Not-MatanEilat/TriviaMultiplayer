#pragma once

#include <map>
#include <vector>

#include "Question.h"

#include "LoggedUser.h"



using std::map;
using std::vector;

typedef struct GameData
{
	Question correctQuestion;
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

private:
	vector<Question> questions;
	map<LoggedUser, GameData> m_players;
	unsigned int gameId;
};

