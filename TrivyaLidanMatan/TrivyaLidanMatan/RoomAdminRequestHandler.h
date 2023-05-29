#pragma once

#include "Room.h"
#include "LoggedUser.h"
#include "RequestHandlerFactory.h"

#include "IRequestHandler.h"

class RoomAdminRequestHandler : public IRequestHandler
{
public:
	RoomAdminRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser user, Room& room);

	bool isRequestRelevant(RequestInfo info) override;
	RequestResult handleRequest(RequestInfo info) override;

private:

	RequestResult closeRoom(RequestInfo info);
	RequestResult startGame(RequestInfo info);
	RequestResult getRoomState(RequestInfo info);

	Room& m_room;
	LoggedUser m_user;
	RoomManager& m_roomManager;
	RequestHandlerFactory& m_handlerFactory;

};

