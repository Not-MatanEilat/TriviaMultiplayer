#pragma once


#include <string>
#include <vector>
#include "json.hpp"

using std::string;
using std::vector;
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
	static vector<unsigned char> serializeResponse(ErrorResponse errorResponse);
	static vector<unsigned char> serializeResponse(LoginResponse loginResponse);
	static vector<unsigned char> serializeResponse(SignupResponse signupResponse);
};

