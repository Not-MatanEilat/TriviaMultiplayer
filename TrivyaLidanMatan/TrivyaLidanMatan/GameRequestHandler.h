#pragma once

#include "IRequestHandler.h"
#include "RequestHandlerFactory.h"

class GameRequestHandler : public IRequestHandler
{
public:

	GameRequestHandler();

	bool isRequestRelevant(RequestInfo info) override;
	RequestResult handleRequest(RequestInfo info) override;
	void handleDisconnect() override;

private:

	RequestResult getQuestion(RequestInfo info);
	RequestResult submitAnswer(RequestInfo info);
	RequestResult getGameResults(RequestInfo info);
	RequestResult leaveGame(RequestInfo info);

	Game 
		

};

