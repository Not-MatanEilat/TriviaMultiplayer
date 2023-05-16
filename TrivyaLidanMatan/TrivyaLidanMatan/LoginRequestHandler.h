#pragma once

#include "RequestHandlerFactory.h"
#include "IRequestHandler.h"


class RequestHandlerFactory;

enum StatusCodes
{
	SUCCESS = 1,
	FAILED = 0
};

class LoginRequestHandler : public IRequestHandler
{
public:
	LoginRequestHandler(RequestHandlerFactory& handlerFactory);

	bool isRequestRelevant(RequestInfo info) override;
	RequestResult handleRequest(RequestInfo info) override;

private:
	RequestResult login(RequestInfo const &info);
	RequestResult signup(RequestInfo const &info);

	RequestHandlerFactory& m_handlerFactory;
};

