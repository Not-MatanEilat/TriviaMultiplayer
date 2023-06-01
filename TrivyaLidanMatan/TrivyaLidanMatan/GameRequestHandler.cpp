#include "GameRequestHandler.h"

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
