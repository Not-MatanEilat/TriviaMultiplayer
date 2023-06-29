#include "RequestHandlerFactory.h"

#include "GameRequestHandler.h"
#include "MenuRequestHandler.h"

/**
 * \brief Constructor to RequestHandler Factory
 * \param mDatabase the DB of the server
 */
RequestHandlerFactory::RequestHandlerFactory(IDataBase* mDatabase) : m_database(mDatabase)
, m_loginManager(mDatabase), m_roomManager(), m_statisticsManager(mDatabase), m_gameManager(mDatabase), m_headToHeadMatchmaker(PLAYERS_PER_HTH_ROOM_AMOUNT, QUESTIONS_AMOUNT_HTH_ROOM_AMOUNT, QUESTION_TIME_HTH, m_roomManager, m_gameManager)
{
}


/**
 * \brief Creates a new Login handler a returns it with the current handler
 * \return The new LoginRequestHandler
 */
LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(*this);
}

/**
 * \brief Creates a new Menu handler a returns it with the current handler
 * \return The new MenuRequestHandler
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
 * \brief Returns a pointer to the database
 * \return IDataBase
 */
IDataBase* RequestHandlerFactory::getDataBase()
{
	return m_database;
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

/**
 * \brief Creates a new Head To Head handler and returns it with the current handler
 * \param loggedUser the logged user
 * \return the new HeadToHeadRoomHandler
 */
HeadToHeadRoomHandler* RequestHandlerFactory::createHeadToHeadRoomHandler(const LoggedUser& loggedUser)
{
	return new HeadToHeadRoomHandler(*this, loggedUser, m_headToHeadMatchmaker);
}




