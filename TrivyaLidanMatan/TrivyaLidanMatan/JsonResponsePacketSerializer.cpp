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



