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
 * \brief Creates a new Room handler a returns it with the current handler
 * \param loggedUser the user that is logged in to the room now
 * \param room the room the user is in now
 * \return The new RoomAdminRequestHandler created
 */
RoomAdminRequestHandler* RequestHandlerFactory::createRoomAdminRequestHandler(const LoggedUser& loggedUser, const Room& room)
{
	return new RoomAdminRequestHandler(*this, loggedUser, room);
}

