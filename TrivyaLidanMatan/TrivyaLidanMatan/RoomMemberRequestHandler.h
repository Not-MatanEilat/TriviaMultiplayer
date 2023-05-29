#pragma once


#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "Communicator.h"

class RequestHandlerFactory;

class RoomMemberRequestHandler : public IRequestHandler
{
public:
	RoomMemberRequestHandler(RequestHandlerFactory& handlerFactory, const LoggedUser& user, Room& room);

	bool isRequestRelevant(RequestInfo info) override;
	RequestResult handleRequest(RequestInfo info) override;

private:
	RequestResult leaveRoom(RequestInfo info);
	RequestResult getRoomState(RequestInfo info);

	Room& m_room;
	LoggedUser m_user;
	RoomManager& m_roomManager;
	RequestHandlerFactory& m_handlerFactory;
};

