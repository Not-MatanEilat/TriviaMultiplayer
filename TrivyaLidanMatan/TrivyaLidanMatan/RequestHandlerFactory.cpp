#include "RequestHandlerFactory.h"

#include "MenuRequestHandler.h"

RequestHandlerFactory::RequestHandlerFactory(IDataBase* mDatabase): m_database(mDatabase), m_loginManager(mDatabase)
{
}

RequestHandlerFactory::RequestHandlerFactory(const LoginManager& mLoginManager, IDataBase* mDatabase): m_loginManager(mLoginManager),
                                                                                                       m_database(mDatabase)
{
}

LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(*this);
}

MenuRequestHandler* RequestHandlerFactory::createMenuRequestHandler()
{
	return new MenuRequestHandler(*this);
}

LoginManager& RequestHandlerFactory::getLoginManager()
{
	return m_loginManager;
}
