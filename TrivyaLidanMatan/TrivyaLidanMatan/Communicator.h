#pragma once


#include <map>
#include <mutex>
#include <thread>
#include <iostream>
#include <WinSock2.h>
#include <Windows.h>

#include "Helper.h"
#include "LoginRequestHandler.h"
#include "RequestHandlerFactory.h"

using std::vector;
using std::string;

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
	LEAVE_ROOM_CODE = 13,
	LEAVE_GAME_CODE = 14,
	GET_QUESTION_CODE = 15,
	SUBMIT_ANSWER_CODE = 16,
	GET_GAME_RESULTS_CODE = 17,
	PLAYER_RESULTS_CODE = 18,
};

class RequestHandlerFactory;

class Communicator
{
public:
	~Communicator();
	void startHandleRequests();

	Communicator(RequestHandlerFactory& handlerFactory);
	void disconnectSocket(SOCKET clientSocket);

private:
	void bindAndListen();
	void handleNewClient(SOCKET clientSocket);


	SOCKET m_serverSocket;
	std::map<SOCKET, IRequestHandler*> m_clients;
	RequestHandlerFactory& m_handlerFactory;
};

