#include "RequestHandlerFactory.h"

RequestHandlerFactory::RequestHandlerFactory(IDataBase* mDatabase): m_database(mDatabase)
{
	m_loginManager = LoginManager();
}

RequestHandlerFactory::RequestHandlerFactory(const LoginManager& mLoginManager, IDataBase* mDatabase): m_loginManager(mLoginManager),
                                                                                                       m_database(mDatabase)
{
}

LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return nullptr;
}

LoginManager& RequestHandlerFactory::getLoginManager()
{
	return m_loginManager;
}
