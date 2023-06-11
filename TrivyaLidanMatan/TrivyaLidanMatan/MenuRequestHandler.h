#pragma once
#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"

class RequestHandlerFactory;
class RoomManager;
class StatisticsManager;

class MenuRequestHandler :
    public IRequestHandler
{
public:
	MenuRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser user);
	bool isRequestRelevant(RequestInfo info) override;
	RequestResult handleRequest(RequestInfo info) override;
	void handleDisconnect() override;

private:
	RequestHandlerFactory& m_handlerFactory;
	LoggedUser m_user;
	RoomManager& m_roomManager;
	StatisticsManager& m_statisticsManager;

	RequestResult logout(RequestInfo const& info);
	RequestResult getRooms(RequestInfo const& info);
	RequestResult getPlayersInRoom(RequestInfo const& info);
	RequestResult getHighScore(RequestInfo const& info);
	RequestResult getPersonalStats(RequestInfo const& info);
	RequestResult joinRoom(RequestInfo const& info);
	RequestResult createRoom(RequestInfo const& info);
	RequestResult addQuestion(RequestInfo const& info);
	RequestResult joinHeadToHead(RequestInfo const& info);
};

