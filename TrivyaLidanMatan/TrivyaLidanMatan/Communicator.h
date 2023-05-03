#pragma once


#include <WinSock2.h>
#include <map>
#include <thread>


#include "Helper.h"

#include "IRequestHandler.h"

class Communicator
{
public:
	void startHandleRequests();

private:

	void bindAndListen();
	void handleNewClient(SOCKET socket);


	SOCKET m_serverSocket;
	std::map<SOCKET, IRequestHandler*> m_clients;
};

