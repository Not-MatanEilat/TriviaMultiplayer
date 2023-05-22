#pragma once
#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"

class RequestHandlerFactory;

class MenuRequestHandler :
    public IRequestHandler
{
public:
	MenuRequestHandler(RequestHandlerFactory& handlerFactory);
	bool isRequestRelevant(RequestInfo info) override;
	RequestResult handleRequest(RequestInfo info) override;

private:
	RequestHandlerFactory& m_handlerFactory;

	RequestResult roomList(RequestInfo const& info);
	RequestResult playersInRoom(RequestInfo const& info);
	RequestResult highScores(RequestInfo const& info);
	RequestResult personalStats(RequestInfo const& info);
	RequestResult joinRoom(RequestInfo const& info);
	RequestResult createRoom(RequestInfo const& info);
};

