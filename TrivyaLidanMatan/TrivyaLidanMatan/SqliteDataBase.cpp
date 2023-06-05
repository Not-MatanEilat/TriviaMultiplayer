#include "SqliteDataBase.h"


/**
 * \brief The constructor for the SqliteDataBase
 */
SqliteDataBase::SqliteDataBase() : _db(DB_PATH)
{
}

/**
 * \brief Will open the database
 * \return True or False, if the database opened
 */
bool SqliteDataBase::open()
{
	return _db.open();
}

/**
 * \brief Will close the database
 * \return True or False, if the database closed
 */
bool SqliteDataBase::close()
{
	return _db.close();
}

/**
 * \brief Function checks if the user exists in the database
 * \param username the username to check
 * \return 1 if the user exists, 0 if not
 */
int SqliteDataBase::doesUserExist(const string &username)
{
	const string sqlStatement = "SELECT * FROM users WHERE username = '$0'";
	vector<string> params = {username};
	Result const result = _db.exec(sqlStatement,  params);
	if (result.empty())
	{
		return 0;
	}
	return 1;
}

/**
 * \brief Function checks if the username given has the password given, returns bool for result
 * \param username the username to check the password for
 * \param password the password to check
 * \return True or False if the password matches the given username's password
 */
int SqliteDataBase::doesPasswordMatch(const string& username, const string& password)
{
	const string sqlStatement = "SELECT * FROM users WHERE username = '$0' AND password = '$1'";
	vector<string> params = { username, password };
	Result const result = _db.exec(sqlStatement, params);
	if (result.empty())
	{
		return 0;
	}
	return 1;
}

/**
 * \brief Function adds a new user to the database
 * \param username the username to add
 * \param password the password to add
 * \param email the email to add
 * \return 1 or 0, depends on if the user was added, 1 for true, 0 for a false
 */
int SqliteDataBase::addNewUser(const string& username, const string& password, const string& email)
{
	string sqlStatement = "INSERT INTO users (username, password, email) VALUES ('$0', '$1', '$2')";
	vector<string> params = { username, password, email };
	_db.exec(sqlStatement, params);

	sqlStatement = "INSERT INTO Statistics (username, averageAnswerTime, correctAnswers, totalAnswers, games) VALUES ('$0', 0, 0, 0, 0)";
	params = { username };
	_db.exec(sqlStatement, params);

	// check if the given user was successfully added
	const string sqlStatement2 = "SELECT * FROM users WHERE username = '$0' AND password = '$1' AND email = '$2' ";
	Result const result = _db.exec(sqlStatement2, params);

	// if the list is empty and we didn't find the user, it means the user wasn't added, so return 0 here
	if (result.empty())
	{
		return 0;
	}

	return 1;
}

std::vector<string> SqliteDataBase::getUsers()
{
	const string sqlStatement = "SELECT * FROM users";
	Result res = _db.exec(sqlStatement);
	std::vector<string> users;
	for (Row& row : res)
	{
		users.push_back(row["username"]);
	}
	return users;
}

/**
 * \brief Compares two scores in descending order.
 * \param user1 user 1
 * \param user2 user 2
 * \return if user1 score is bigger than user2 score
 */
bool SqliteDataBase::compareScoresByUserName(string& user1, string& user2)
{
	return (getPlayerScore(user1) > getPlayerScore(user2));
}

/**
 * \brief get the high scores from the database
 * \return the high scores
 */
std::vector<string> SqliteDataBase::getHighScores()
{
	std::vector<string> users = getUsers();
	std::sort(users.begin(), users.end(), [&](string a, string b) {return getPlayerScore(a) > getPlayerScore(b); });
	for (auto& user : users)
	{
		user += " - " + std::to_string(getPlayerScore(user));
	}
	return users;
}

/**
 * \brief get question from the database
 * \param questionsNo question number
 * \return question by number
 */
std::vector<Question> SqliteDataBase::getQuestions(int questionsNo)
{
	const string sqlStatement = "SELECT * FROM questions ORDER BY random() LIMIT $0";
	vector<string> params = { std::to_string(questionsNo) };
	Result res = _db.exec(sqlStatement, params);
	std::vector<Question> questions;
	for (Row& row : res)
	{
		vector<string> answers;
		answers.push_back(row["correctAnswer"]);
		answers.push_back(row["answer2"]);
		answers.push_back(row["answer3"]);
		answers.push_back(row["answer4"]);
		Question question(row["question"], answers);
		questions.push_back(question);
	}
	return questions;
}

/**
 * \brief get average answer time from the database
 * \param username username
 * \return the average answer time
 */
float SqliteDataBase::getPlayerAverageAnswerTime(string const& username)
{
	Row stats = getPlayerStatistics(username);
	return std::stof(stats["averageAnswerTime"]);
}

/**
 * \brief get correct answers from the database
 * \param username username
 * \return the correct answers
 */
int SqliteDataBase::getNumOfCorrectAnswers(string const& username)
{
	Row stats = getPlayerStatistics(username);
	return std::stoi(stats["correctAnswers"]);
}


/**
 * \brief get total answers from the database
 * \param username username
 * \return the total answers
 */
int SqliteDataBase::getNumOfTotalAnswers(string const& username)
{
	Row stats = getPlayerStatistics(username);
	return std::stoi(stats["totalAnswers"]);
}


/**
 * \brief get games from the database
 * \param username username
 * \return the games
 */
int SqliteDataBase::getNumOfPlayerGames(string const& username)
{
	Row stats = getPlayerStatistics(username);
	return std::stoi(stats["games"]);
}


/**
 * \brief get score from the database
 * \param username username
 * \return the score
 */
int SqliteDataBase::getPlayerScore(string const& username)
{
	int correctAnswers = getNumOfCorrectAnswers(username);
	float averageAnswerTime = getPlayerAverageAnswerTime(username);
	int score = (correctAnswers * 10) - (averageAnswerTime / 2);
	return score;
}

void SqliteDataBase::setPlayerStatistics(string const& username, Row stats)
{
	const string sqlStatement = "UPDATE Statistics SET averageAnswerTime = $0 AND correctAnswers = $1 AND totalAnswers = $2 AND games = $3 WHERE username == '$4'";
	vector<string> params = { stats["averageAnswerTime"], stats["correctAnswers"], stats["totalAnswers"], stats["games"], username };
	_db.exec(sqlStatement, params);
}

/**
 * \brief get player statistics from the database
 * \param username username
 * \return the player statistics
 */
Row SqliteDataBase::getPlayerStatistics(string const& username)
{
	const string sqlStatement = "SELECT * FROM Statistics WHERE username = '$0'";
	vector<string> params = { username };
	Result res = _db.exec(sqlStatement, params);
	if (res.empty())
	{
		return {};
	}

	return res[0];
}
