#pragma once


#include <WinSock2.h>
#include <map>


#include "Helper.h"

#include "IRequestHandler.h"

class Communicator
{
public:
	void startHandleRequests();

private:

	void bindAndListen();


	SOCKET m_serverSocket;
	std::map<SOCKET, IRequestHandler*> m_clients;
};

