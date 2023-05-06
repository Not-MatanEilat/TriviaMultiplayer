#include "JsonResponsePacketSerializer.h"

/**
 * \brief The function will take an error response and serialize it to a string ("message" : "error message")
 * \param errorResponse the error response to serialize
 * \return error response serialized to a string
 */
string JsonResponsePacketSerializer::serializeResponse(ErrorResponse errorResponse)
{
	
	json j;
	j["message"] = errorResponse.message;
	return j.dump();

}

/**
 * \brief The function will take a signup response and serialize it to a string ("status" : "status")
 * \param loginResponse The login response to serialize
 * \return login response serialized to a string
 */
string JsonResponsePacketSerializer::serializeResponse(LoginResponse loginResponse)
{
	json j;
	j["status"] = loginResponse.status;
	return j.dump();
}




