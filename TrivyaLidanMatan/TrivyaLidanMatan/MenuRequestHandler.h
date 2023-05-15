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
};

