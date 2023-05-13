#pragma once

#include "LoginManager.h"
#include "SqliteDataBase.h"
#include "LoginRequestHandler.h"



class RequestHandlerFactory
{
public:
	LoginRequestHandler* createLoginRequestHandler();
	LoginManager& getLoginManager();

private:
	LoginManager m_loginManager;
	SqliteDataBase m_database;
};
