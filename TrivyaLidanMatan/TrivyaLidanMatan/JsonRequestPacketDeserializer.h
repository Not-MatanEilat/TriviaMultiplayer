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


class JsonRequestPacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(Buffer const &buffer);
	static SignupRequest deserializeSignupRequest(Buffer const &buffer);
};

