#include "GameRequestHandler.h"

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

