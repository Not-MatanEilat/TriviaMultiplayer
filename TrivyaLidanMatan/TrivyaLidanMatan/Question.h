#pragma once
#include "IDataBase.h"


class Question
{
public:
	Question(const string& question, const vector<string>& possibleAnswers);

	string getQuestion() const;
	vector<string> getPossibleAnswers() const;
	int getCorrectAnswerId() const;
private:
	string m_question;
	vector<string> m_possibleAnswers;
};

