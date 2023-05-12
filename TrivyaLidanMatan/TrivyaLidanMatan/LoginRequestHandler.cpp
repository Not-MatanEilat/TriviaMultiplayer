#include "LoginRequestHandler.h"

#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

/**
 * \brief checks if the request is relevant
 * \return true if request is relevant
 */
bool LoginRequestHandler::isRequestRelevant(RequestInfo info)
{
	return info.requestId == LOGIN_CODE || info.requestId == SIGNUP_CODE;
}

/**
 * \brief handles the request
 * \return request result
 */
RequestResult LoginRequestHandler::handleRequest(RequestInfo info)
{
	string msg = Helper::getStringFromBuffer(info.buffer);
	RequestResult result;
	result.newHandler = this;
	if (info.requestId == LOGIN_CODE)
	{
		TRACE("got login request");
		LoginRequest loginRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(msg);

		LoginResponse response;
		response.status = 1;

		Buffer buffer = JsonResponsePacketSerializer::serializeResponse(response);
		result.response = buffer;
	}
	else if (info.requestId == SIGNUP_CODE)
	{
		TRACE("got signup request");
		SignupRequest signupRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(msg);

		SignupResponse response;
		response.status = 1;

		Buffer buffer = JsonResponsePacketSerializer::serializeResponse(response);
		result.response = buffer;
	}
	else
	{
		ErrorResponse response;
		response.message = "Invalid message code for this state";

		Buffer buffer = JsonResponsePacketSerializer::serializeResponse(response);
		result.response = buffer;
	}
	return result;
}