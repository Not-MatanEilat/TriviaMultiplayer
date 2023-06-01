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