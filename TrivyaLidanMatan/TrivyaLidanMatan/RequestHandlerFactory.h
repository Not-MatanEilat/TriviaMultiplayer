#pragma once

#include "LoginManager.h"
#include "SqliteDataBase.h"
#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"
#include "RoomManager.h"
#include "StatisticsManager.h"
#include "GameManager.h"
#include "Matchmaker.h"
#include "GameRequestHandler.h"
#include "RoomAdminRequestHandler.h"
#include "RoomMemberRequestHandler.h"
#include "HeadToHeadRoomHandler.h"

class LoginRequestHandler;
class MenuRequestHandler;
class RoomAdminRequestHandler;
class RoomMemberRequestHandler;
class GameRequestHandler;
class HeadToHeadRoomHandler;

class RequestHandlerFactory
{
public:
	RequestHandlerFactory(IDataBase* mDatabase);

	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHandler(const LoggedUser& loggedUser);
	LoginManager& getLoginManager();
	RoomManager& getRoomManager();
	StatisticsManager& getStatisticsManager();
	GameManager& getGameManager();
	IDataBase* getDataBase();
	RoomAdminRequestHandler* createRoomAdminRequestHandler(const LoggedUser& loggedUser, Room& room);
	RoomMemberRequestHandler* createRoomMemberRequestHandler(const LoggedUser& loggedUser, Room& room);
	GameRequestHandler* createGameRequestHandler(const LoggedUser& loggedUser, Game& game);
	HeadToHeadRoomHandler* createHeadToHeadRoomHandler(const LoggedUser& loggedUser);

private:
	LoginManager m_loginManager;
	RoomManager m_roomManager;
	StatisticsManager m_statisticsManager;
	GameManager m_gameManager;
	Matchmaker m_headToHeadMatchmaker;
	IDataBase* m_database;
};
