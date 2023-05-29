#pragma once


#include <map>
#include <thread>
#include <iostream>
#include <WinSock2.h>
#include <Windows.h>

#include "Helper.h"
#include "LoginRequestHandler.h"
#include "RequestHandlerFactory.h"

using std::vector;
using std::string;

typedef unsigned char byte;
typedef vector<byte> Buffer;

enum RESPONSE_CODES
{
	ERROR_CODE = 0,
	LOGIN_CODE = 1,
	SIGNUP_CODE = 2,
	LOGOUT_CODE = 3,
	ROOMS_LIST_CODE = 4,
	PLAYERS_IN_ROOM_CODE = 5,
	HIGH_SCORES_CODE = 6,
	PERSONAL_STATS_CODE = 7,
	JOIN_ROOM_CODE = 8,
	CREATE_ROOM_CODE = 9,
	CLOSE_ROOM_CODE = 10,
	START_GAME_CODE = 11,
	ROOM_STATE_CODE = 12,
	LEAVE_ROOM_CODE = 13
};

class RequestHandlerFactory;

class Communicator
{
public:
	void startHandleRequests();

	Communicator(RequestHandlerFactory& handlerFactory);

private:
	void bindAndListen();
	void handleNewClient(SOCKET clientSocket);


	SOCKET m_serverSocket;
	std::map<SOCKET, IRequestHandler*> m_clients;
	RequestHandlerFactory& m_handlerFactory;
};

