#pragma once


#include <map>
#include <thread>
#include <iostream>
#include <WinSock2.h>
#include <Windows.h>

#include "Helper.h"
#include "LoginRequestHandler.h"

using std::vector;

typedef unsigned char byte;
typedef vector<byte> Buffer;

class Communicator
{
public:
	void startHandleRequests();

	Communicator();

private:
	void bindAndListen();
	void handleNewClient(SOCKET clientSocket);


	SOCKET m_serverSocket;
	std::map<SOCKET, LoginRequestHandler*> m_clients;
};

