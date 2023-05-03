#pragma once


#include <WinSock2.h>
#include <map>

#include "IRequestHandler.h"

class Communicator
{
public:
	void startHandleRequests();

private:
	SOCKET m_serverSocket;
	std::map<SOCKET, IRequestHandler*> m_clients;
};

