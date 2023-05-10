#pragma once

#include <ctime>
#include "Communicator.h"

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
	virtual bool isRequestRelevant(RequestInfo) = 0;
	virtual RequestResult handleRequest(RequestInfo) = 0;
};
