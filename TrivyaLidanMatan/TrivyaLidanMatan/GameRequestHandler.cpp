#include "GameRequestHandler.h"

#include <random>

#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

/**
 * \brief Constructor for the game request handler
 * \param requestHandlerFactory the factory for creating request handlers
 * \param user the user in game
 * \param game the game user's in
 */
GameRequestHandler::GameRequestHandler(RequestHandlerFactory& requestHandlerFactory, const LoggedUser& user, Game& game) : m_handlerFactory(requestHandlerFactory), m_user(user), m_game(game), m_gameManager(requestHandlerFactory.getGameManager())
{

}

/**
 * \brief Checks if the request given was relevant
 * \param info the info of request
 * \return true if relevant and false if not
 */
bool GameRequestHandler::isRequestRelevant(RequestInfo info)
{
	int code = info.requestId;
	return code == LEAVE_GAME_CODE || code == GET_QUESTION_CODE || code == SUBMIT_ANSWER_CODE || code == GET_GAME_RESULTS_CODE;
}

/**
 * \brief Handlers the request as the game userr
 * \param info the info of request
 * \return The result for request
 */
RequestResult GameRequestHandler::handleRequest(RequestInfo info)
{
	int code = info.requestId;
	RequestResult result;

	try
	{
		if (code == LEAVE_GAME_CODE)
		{
			result = leaveGame(info);
		}
		else if (code == GET_QUESTION_CODE)
		{
			result = getQuestion(info);
		}
		else if (code == SUBMIT_ANSWER_CODE)
		{
			result = submitAnswer(info);
		}
		else if (code == GET_GAME_RESULTS_CODE)
		{
			result = getGameResults(info);
		}
	}
	catch (const std::exception& e)
	{
		ErrorResponse error;
		error.message = "Something went wrong: " + std::string(e.what());
		TRACE("GameRequestHandler " << m_user.getUsername() << ": " << error.message)
			result.response = JsonResponsePacketSerializer::serializeResponse(error);
		result.newHandler = this;
	}

	return result;
}

/**
 * \brief handles if user disconnectsted
 */
void GameRequestHandler::handleDisconnect()
{
	TRACE("GameRequestHandler " << m_user.getUsername() << ": disconnected")
		m_game.removePlayer(m_user);
	m_handlerFactory.getLoginManager().logout(m_user.getUsername());
	m_gameManager.getGame(m_user).removePlayer(m_user);
}


/**
 * \brief Removes users from the current game
 * \param info the info of request
 * \return the result of the given request
 */
RequestResult GameRequestHandler::leaveGame(RequestInfo info)
{
	RequestResult result;

	LeaveGameResponse response;

	m_game.removePlayer(m_user.getUsername());
	response.status = SUCCESS;

	result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	result.response = JsonResponsePacketSerializer::serializeResponse(response);


	TRACE("User: " + m_user.getUsername() + " has left the game: " + std::to_string(m_game.getGameId()));

	return result;
}

/**
 * \brief Submits the answer user wanted
 * \param info the infor of request
 * \return the result of the given request
 */
RequestResult GameRequestHandler::submitAnswer(RequestInfo info)
{
	RequestResult result;

	SubmitAnswerRequest request = JsonRequestPacketDeserializer::deserializeSubmitAnswerRequest(info.buffer);
	SubmitAnswerResponse response;

	response.status = SUCCESS;

	bool correct = m_game.submitAnswer(m_user.getUsername(), request.answerId);
	response.correctAnswer = correct;
	result.newHandler = this;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);

	TRACE(" User: " + m_user.getUsername() + " has submitted an answer, the answer id is: " + std::to_string(request.answerId));

	return result;
}

/**
 * \brief Gets the results of current game
 * \param info info of the request
 * \return the result of the given request
 */
RequestResult GameRequestHandler::getGameResults(RequestInfo info)
{
	RequestResult result;


	if (!m_game.isGameOver(m_user))
	{

		GetGameResultsResponse response;

		response.status = SUCCESS;

		map<string, GameData> playersList = m_game.getPlayers();

		for (const auto& player : playersList)
		{
			PlayerResults playerResults;

			string loggedUser = player.first;
			GameData gameData = player.second;


			playerResults.username = loggedUser;

			playerResults.correctAnswerCount = gameData.correctAnswerCount;
			playerResults.wrongAnswerCount = gameData.wrongAnswerCount;
			playerResults.averageAnswerTime = gameData.averageAnswerTime;


			response.results.push_back(playerResults);
		}

		result.newHandler = this;
		result.response = JsonResponsePacketSerializer::serializeResponse(response);

	}
	else
	{
		GetGameResultsResponse response;

		response.status = FAILED;
		response.results = {};

		result.newHandler = this;
		result.response = JsonResponsePacketSerializer::serializeResponse(response);

	}


	return result;

}

/**
 * \brief Gets question for user with answers( order is just randomized)
 * \param info info of the request
 * \return the result of the given request
 */
RequestResult GameRequestHandler::getQuestion(RequestInfo info)
{
	RequestResult result;

	GetQuestionResponse response;
	
	response.status = SUCCESS;

	Question* questionP = (m_game.getQuestionForUser(m_user));
	Question question = *(questionP);

	response.question = question.getQuestion();

	// randomize the answers/correct answer order
	vector<string> answers = question.getPossibleAnswers();

	// std::shuffle(answers.begin(), answers.end(), std::random_device());
	// shuffle will be client side ONLY

	int i = 1;
	for (auto answer : answers)
	{
		std::pair<int, string> answerPair;

		answerPair.first = i;
		answerPair.second = answer;
		response.answers.insert(answerPair);
		i += 1;
	}

	TRACE("\nUser: " + m_user.getUsername() + " has request a question: " + question.getQuestion()
	+ "\nAnswers are:"
    + "\nAnswer1: " + question.getPossibleAnswers()[0] + " - Right Answer"
    + "\nAnswer2: " + question.getPossibleAnswers()[1] + " - Wrong Answer"
    + "\nAnswer3: " + question.getPossibleAnswers()[2] + " - Wrong Answer"
    + "\nAnswer4: " + question.getPossibleAnswers()[3] + " - Wrong Answer");
	
	result.newHandler = this;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);

	return result;
}






