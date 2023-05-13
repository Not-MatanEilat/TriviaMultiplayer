#pragma once

#include "LoginManager.h"
#include "SqliteDataBase.h"
#include "LoginRequestHandler.h"


class LoginRequestHandler;

class RequestHandlerFactory
{
public:
	RequestHandlerFactory(IDataBase* mDatabase);

	RequestHandlerFactory(const LoginManager& mLoginManager, IDataBase* mDatabase);

	LoginRequestHandler* createLoginRequestHandler();
	LoginManager& getLoginManager();

private:
	LoginManager m_loginManager;
	IDataBase* m_database;
};
