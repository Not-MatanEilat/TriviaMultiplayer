#pragma once

#include "LoginManager.h"
#include "SqliteDataBase.h"
#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"
#include "RoomManager.h"
#include "StatisticsManager.h"
#include "RoomAdminRequestHandler.h"
#include "RoomMemberRequestHandler.h"

class LoginRequestHandler;
class MenuRequestHandler;

class RequestHandlerFactory
{
public:
	RequestHandlerFactory(IDataBase* mDatabase);

	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHandler(LoggedUser loggedUser);
	LoginManager& getLoginManager();
	RoomManager& getRoomManager();
	StatisticsManager& getStatisticsManager();
	CreateRoomAdminRequestHandler* createRoomAdminRequestHandler(LoggedUser loggedUser);



private:
	LoginManager m_loginManager;
	RoomManager m_roomManager;
	StatisticsManager m_statisticsManager;
	IDataBase* m_database;
};
