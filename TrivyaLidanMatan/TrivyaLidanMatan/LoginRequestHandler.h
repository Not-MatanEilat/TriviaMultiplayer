#pragma once


#include "IRequestHandler.h"

class LoginRequestHandler : public IRequestHandler
{
public:
	bool isRequestRelevant(RequestInfo) override;
	RequestResult handleRequest(RequestInfo) override;
};

