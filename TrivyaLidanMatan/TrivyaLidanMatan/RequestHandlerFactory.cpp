#include "RequestHandlerFactory.h"

#include "MenuRequestHandler.h"

/**
 * \brief Constructor to RequestHandler Factory
 * \param mDatabase the DB of the server
 */
RequestHandlerFactory::RequestHandlerFactory(IDataBase* mDatabase): m_database(mDatabase), m_loginManager(mDatabase)
{
}

/**
 * \brief Constructor to RequestHandler Factory
 * \param mLoginManager the login manager of the server
 * \param mDatabase the DB of the server
 */
RequestHandlerFactory::RequestHandlerFactory(const LoginManager& mLoginManager, IDataBase* mDatabase): m_loginManager(mLoginManager),
                                                                                                       m_database(mDatabase)
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
MenuRequestHandler* RequestHandlerFactory::createMenuRequestHandler()
{
	return new MenuRequestHandler(*this);
}

/**
 * \brief Returns a ref of the login manager
 * \return LoginManager
 */
LoginManager& RequestHandlerFactory::getLoginManager()
{
	return m_loginManager;
}
