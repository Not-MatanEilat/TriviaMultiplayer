#pragma once


#include <string>
#include <vector>
#include "json.hpp"
#include "Communicator.h"

using std::string;
using std::vector;
using json = nlohmann::json;

typedef struct LoginResponse
{
	unsigned int status;

} LoginResponse;

typedef struct SignupResponse
{
	unsigned int status;
} SignupResponse;
typedef struct ErrorResponse
{
	string message;
} ErrorResponse;

enum RESPONSE_CODES
{
	ERROR_CODE = 0,
	LOGIN_CODE = 1,
	SIGNUP_CODE = 2
};

class JsonResponsePacketSerializer
{


public:
	static Buffer serializeResponseFromJson(byte code, json j);
	static Buffer serializeResponse(LoginResponse response);
	static Buffer serializeResponse(SignupResponse response);
	static Buffer serializeResponse(ErrorResponse response);
};

