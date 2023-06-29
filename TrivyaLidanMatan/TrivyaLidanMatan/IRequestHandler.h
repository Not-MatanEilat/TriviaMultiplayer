#pragma once

#include <ctime>
#include "Helper.h"

class IRequestHandler;

typedef struct RequestInfo
{
	int requestId;
	clock_t receivalTime;
	Buffer buffer;
} RequestInfo;

typedef struct RequestResult
{
	IRequestHandler* newHandler;
	Buffer response;
} RequestResult;

class IRequestHandler
{
public:
	virtual ~IRequestHandler() = default;
	virtual bool isRequestRelevant(RequestInfo info) = 0;
	virtual RequestResult handleRequest(RequestInfo info) = 0;
	virtual void handleDisconnect() = 0;
};
