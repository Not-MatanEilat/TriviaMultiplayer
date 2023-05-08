#include "JsonRequestPacketDeserializer.h"

/**
 * \brief deserialize LoginRequest
 * \param buffer buffer of json data
 * \return deserialized LoginRequest
 */
LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(string buffer)
{
	json j = json::parse(buffer);

	LoginRequest request;
	request.username = j["username"];
	request.password = j["password"];

	return request;

}

/**
 * \brief deserialize SignupRequest
 * \param buffer buffer of json data
 * \return deserialized SignupRequest
 */
SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(string buffer)
{
	json j = json::parse(buffer);

	SignupRequest request;
	request.username = j["username"];
	request.password = j["password"];
	request.email = j["email"];

	return request;
}
