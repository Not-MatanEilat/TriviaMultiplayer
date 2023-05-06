#pragma once


#include <string>
#include "json.hpp"

using std::string;
using json = nlohmann::json;

class JsonResponsePacketSerializer
{

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



public:
	static string serializeResponse(ErrorResponse errorResponse);
	static string serializeResponse(LoginResponse loginResponse);
	static string serializeResponse(SignupResponse signupResponse);

};

