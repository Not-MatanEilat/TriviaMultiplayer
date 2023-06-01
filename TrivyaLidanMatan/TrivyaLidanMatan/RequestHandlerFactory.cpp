#include "RequestHandlerFactory.h"

#include "MenuRequestHandler.h"

/**
 * \brief Constructor to RequestHandler Factory
 * \param mDatabase the DB of the server
 */
RequestHandlerFactory::RequestHandlerFactory(IDataBase* mDatabase): m_database(mDatabase), m_loginManager(mDatabase), m_roomManager(), m_statisticsManager(mDatabase)
{
}


/**
 * \brief Creates a new Login handler a returns it with the current handler
 * \return 
 */
LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(*this);
}

/**
 * \brief Creates a new Menu handler a returns it with the current handler
 * \return 
 */
MenuRequestHandler* RequestHandlerFactory::createMenuRequestHandler(const LoggedUser& loggedUser)
{
	return new MenuRequestHandler(*this, loggedUser);
}

/**
 * \brief Returns a ref of the login manager
 * \return LoginManager
 */
LoginManager& RequestHandlerFactory::getLoginManager()
{
	return m_loginManager;
}

/**
 * \brief Returns a ref of the room manager
 * \return RoomManager
 */
RoomManager& RequestHandlerFactory::getRoomManager()
{
	return m_roomManager;
}

/**
 * \brief Returns a ref of the statistics manager
 * \return StatisticsManager
 */
StatisticsManager& RequestHandlerFactory::getStatisticsManager()
{
	return m_statisticsManager;
}

/**
 * \brief Returns a ref of the game manager
 * \return GameManager
 */
GameManager& RequestHandlerFactory::getGameManager()
{
	return m_gameManager;
}

/**
 * \brief Creates a new Room handler a returns it with the current handler
 * \param loggedUser the user that is logged in to the room now
 * \param room the room the user is in now
 * \return The new RoomAdminRequestHandler created
 */
RoomAdminRequestHandler* RequestHandlerFactory::createRoomAdminRequestHandler(const LoggedUser& loggedUser, Room& room)
{
	return new RoomAdminRequestHandler(*this, loggedUser, room);
}

/**
 * \brief Creates a new Room handler a returns it with the current handler
 * \param loggedUser the user that is logged in to the room now
 * \param room room the room the user is in now
 * \return The new RoomMemberRequestHandler created
 */
RoomMemberRequestHandler* RequestHandlerFactory::createRoomMemberRequestHandler(const LoggedUser& loggedUser, Room& room)
{
	return new RoomMemberRequestHandler(*this, loggedUser, room);
}

/**
 * \brief Creates a new Game handler and returns it with the current handler
 * \param loggedUser the user that is logged in to the game now
 * \param game game the game  the user is in now
 * \return the new GameRequestHandler created
 */
GameRequestHandler* RequestHandlerFactory::createGameRequestHandler(const LoggedUser& loggedUser, Game& game)
{
	return new GameRequestHandler(*this, loggedUser, game);
}



