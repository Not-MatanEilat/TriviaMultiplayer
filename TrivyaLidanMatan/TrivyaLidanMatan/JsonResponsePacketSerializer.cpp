#include "JsonResponsePacketSerializer.h"

/**
 * \brief The function will take an error response and serialize it to a string ("message" : "error message")
 * \param errorResponse the error response to serialize
 * \return error response serialized to a string
 */
Buffer JsonResponsePacketSerializer::serializeResponse(ErrorResponse errorResponse)
{

	json j;
	j["message"] = errorResponse.message;
	Buffer vec = serializeResponseFromJson(ERROR_CODE, j);
	return vec;

}

/**
 * \brief serialize response from json
 * \param code response code
 * \param j json object
 * \return Buffer of response
 */
Buffer JsonResponsePacketSerializer::serializeResponseFromJson(byte code, json j)
{
	string jStr = j.dump();
	long len = jStr.length();
	byte bytes[4];

	bytes[0] = (len >> 24) & 0xFF;
	bytes[1] = (len >> 16) & 0xFF;
	bytes[2] = (len >> 8) & 0xFF;
	bytes[3] = len & 0xFF;

	Buffer jsonData(jStr.begin(), jStr.end());
	Buffer result = { code, bytes[0], bytes[1], bytes[2], bytes[3] };
	for (auto& c : jsonData)
	{
		result.push_back(c);
	}
	return result;

}

/**
 * \brief The function will take a login response and serialize it to a string ("status" : "status")
 * \param loginResponse The login response to serialize
 * \return login response serialized to a string
 */
Buffer JsonResponsePacketSerializer::serializeResponse(LoginResponse loginResponse)
{
	json j;
	j["status"] = loginResponse.status;
	Buffer vec = serializeResponseFromJson(SIGNUP_CODE, j);
	return vec;
}

/**
 * \brief The function will take a signup response and serialize it to a string ("status" : "status")
 * \param signupResponse the signup response to serialize
 * \return signup response serialized to a string
 */
Buffer JsonResponsePacketSerializer::serializeResponse(SignupResponse signupResponse)
{
	json j;
	j["status"] = signupResponse.status;
	Buffer vec = serializeResponseFromJson(LOGIN_CODE, j);
	return vec;
}





