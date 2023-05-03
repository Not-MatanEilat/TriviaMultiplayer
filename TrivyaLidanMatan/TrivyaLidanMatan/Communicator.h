#pragma once


#include <WinSock2.h>
#include <map>
#include <thread>
#include <iostream>

#include "Helper.h"

class Communicator
{
public:
	void startHandleRequests();

private:

	void bindAndListen();
	void handleNewClient(SOCKET clientSocket);


	SOCKET m_serverSocket;
	std::map<SOCKET, IRequestHandler*> m_clients;
};

