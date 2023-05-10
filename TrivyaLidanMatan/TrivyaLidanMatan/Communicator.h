#pragma once


#include <map>
#include <thread>
#include <iostream>
#include <WinSock2.h>
#include <Windows.h>

#include "Helper.h"
#include "LoginRequestHandler.h"

using std::vector;
using std::string;

typedef unsigned char byte;
typedef vector<byte> Buffer;

enum RESPONSE_CODES
{
	ERROR_CODE = 0,
	LOGIN_CODE = 1,
	SIGNUP_CODE = 2
};

class Communicator
{
public:
	void startHandleRequests();

	Communicator();

private:
	void bindAndListen();
	void handleNewClient(SOCKET clientSocket);


	SOCKET m_serverSocket;
	std::map<SOCKET, IRequestHandler*> m_clients;
};

