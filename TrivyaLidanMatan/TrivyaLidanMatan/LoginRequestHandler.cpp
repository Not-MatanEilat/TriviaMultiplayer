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
	RequestResult result;
	result.newHandler = this;
	if (info.requestId == LOGIN_CODE)
	{
		TRACE("got login request");
		LoginRequest loginRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(info.buffer);

		LoginResponse response;
		response.status = 1;

		Buffer buffer = JsonResponsePacketSerializer::serializeResponse(response);
		result.response = buffer;
	}
	else if (info.requestId == SIGNUP_CODE)
	{
		TRACE("got signup request");
		SignupRequest signupRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(info.buffer);

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


/**
 * \brief The function will take a login request and deserialize it to a login request object
 * \param info the info of the request
 * \return the request login result
 */
RequestResult LoginRequestHandler::login(RequestInfo const &info)
{
	LoginRequest loginRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(info.buffer);
	LoginResponse response;
	response.status = LOGIN_CODE;
	Buffer const buffer = JsonResponsePacketSerializer::serializeResponse(response);

	RequestResult result;

	result.newHandler = this;
	result.response = buffer;

	return result;
}

/**
 * \brief The function will take a signup request and deserialize it to a signup request object
 * \param info the info of the request
 * \return the request signup result
 */
RequestResult LoginRequestHandler::signup(RequestInfo const &info)
{
	SignupRequest signupRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(info.buffer);
	SignupResponse response;
	response.status = SIGNUP_CODE;
	Buffer const buffer = JsonResponsePacketSerializer::serializeResponse(response);

	RequestResult result;

	result.newHandler = this;
	result.response = buffer;

	return result;
}