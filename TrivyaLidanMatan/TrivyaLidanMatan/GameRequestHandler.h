#pragma once

#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"
#include "Communicator.h""

class GameRequestHandler : public IRequestHandler
{
public:

	GameRequestHandler(RequestHandlerFactory& requestHandlerFactory, const LoggedUser& user, Game& game);

	bool isRequestRelevant(RequestInfo info) override;
	RequestResult handleRequest(RequestInfo info) override;
	void handleDisconnect() override;

private:

	RequestResult getQuestion(RequestInfo info);
	RequestResult submitAnswer(RequestInfo info);
	RequestResult getGameResults(RequestInfo info);
	RequestResult leaveGame(RequestInfo info);

	Game& m_game;
	LoggedUser m_user;
	GameManager& m_gameManager;
	RequestHandlerFactory& m_handlerFactory;
		

};

