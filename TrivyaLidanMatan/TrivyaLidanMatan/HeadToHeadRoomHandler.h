#pragma once


#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "Communicator.h"


#define PLAYERS_PER_HTH_ROOM_AMOUNT 2
#define QUESTIONS_AMOUNT_HTH_ROOM_AMOUNT 15
#define QUESTION_TIME_HTH 12

class HeadToHeadRoomHandler : public IRequestHandler
{
public:

	HeadToHeadRoomHandler(RequestHandlerFactory& handlerFactory, const LoggedUser& user, Matchmaker& matchmaker);

	bool isRequestRelevant(RequestInfo info) override;
	RequestResult handleRequest(RequestInfo info) override;
	void handleDisconnect() override;

private:

	RequestResult getState(RequestInfo info);
	RequestResult leaveRoom(RequestInfo info);
	RequestResult startGame(RequestInfo info);

	Matchmaker& m_matchmaker;
	LoggedUser m_user;
	RequestHandlerFactory& m_handlerFactory;

};

