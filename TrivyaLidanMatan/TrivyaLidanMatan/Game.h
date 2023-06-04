#pragma once

#include <map>
#include <vector>

#include "Question.h"

#include "LoggedUser.h"



using std::map;
using std::vector;

typedef struct GameData
{
	Question* currentQuestion = nullptr;
	unsigned int correctAnswerCount = 0;
	unsigned int wrongAnswerCount = 0;
	float averageAnswerTime = 0;
} GameData;


class Game
{
public:
	Game(vector<Question> questions, const map<string, GameData>& players, unsigned gameId);

	Question* getQuestionForUser(const LoggedUser& loggedUser);
	bool submitAnswer(const LoggedUser& loggedUser, unsigned int answerId);
	void removePlayer(const LoggedUser& loggedUser);
	unsigned int getGameId() const;

	bool isGameOver(const LoggedUser& loggedUser);
	map<string, GameData> getPlayers() const;
	int amountOfQuestionsLeft(const LoggedUser& loggedUser);

private:
	vector<Question> m_questions;
	map<string, GameData> m_players;
	unsigned int m_gameId;
};

