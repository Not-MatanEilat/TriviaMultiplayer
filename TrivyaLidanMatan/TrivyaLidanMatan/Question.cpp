#include "Question.h"

Question::Question(const string& question, const vector<string>& possibleAnswers): m_question(question),
	m_possibleAnswers(possibleAnswers)
{
}

/**
 * \brief return the question
 * \return the question
 */
string Question::getQuestion() const
{
	return m_question;
}

/**
 * \brief return the possible answers
 * \return the possible answers
 */
vector<string> Question::getPossibleAnswers() const
{
	return m_possibleAnswers;
}

/**
 * \brief return the correct answer id
 * \return the correct answer id
 */
int Question::getCorrectAnswerId() const
{
	return 1;
}
