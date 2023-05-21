#pragma once

#include <string>
#include <vector>

#include "Communicator.h"
#include "JsonResponsePacketSerializer.h"


using std::vector;
using std::string;

typedef struct LoginRequest
{
	string username;
	string password;
} LoginRequest;

typedef struct SignupRequest
{
	string username;
	string password;
	string email;
} SignupRequest;

typedef struct GetPlayersInRoomRequest
{
	unsigned int roomId;
} GetPlayersInRoomRequest;

typedef struct JoinRoomRequest
{
	unsigned int roomId;
} JoinRoomRequest;

typedef struct CreateRoomRequest
{
	string roomName;
	unsigned int maxUsers;
	unsigned int questionCount;
	unsigned int answerTimeout;
} CreateRoomRequest;


class JsonRequestPacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(Buffer const &buffer);
	static SignupRequest deserializeSignupRequest(Buffer const &buffer);
};

