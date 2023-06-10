#pragma once


#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "Communicator.h"

class HeadToHeadRoomHandler : public IRequestHandler
{
public:

	HeadToHeadRoomHandler(RequestHandlerFactory& handlerFactory, const LoggedUser& user, Room& room);

	bool isRequestRelevant(RequestInfo info) override;
	RequestResult handleRequest(RequestInfo info) override;
	void handleDisconnect() override;

private:

	RequestResult getRoomState(RequestInfo info);
	RequestResult leaveRoom(RequestInfo info);
	RequestResult startGame(RequestInfo info);

	void checkForGameStart();

	Room& m_room;
	LoggedUser m_user;
	RoomManager& m_roomManager;
	RequestHandlerFactory& m_handlerFactory;

};

