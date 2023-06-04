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
