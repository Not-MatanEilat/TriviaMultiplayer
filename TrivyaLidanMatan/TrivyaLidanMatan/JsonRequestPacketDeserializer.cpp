#include "JsonRequestPacketDeserializer.h"

/**
 * \brief deserialize LoginRequest
 * \param buffer buffer of json data
 * \return deserialized LoginRequest
 */
LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(Buffer const &buffer)
{
	string bufferStr = Helper::getStringFromBuffer(buffer);

	json j = json::parse(bufferStr);

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
SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(Buffer const &buffer)
{
	string bufferStr = Helper::getStringFromBuffer(buffer);

	json j = json::parse(bufferStr);

	SignupRequest request;
	request.username = j["username"];
	request.password = j["password"];
	request.email = j["email"];

	return request;
}


/**
 * \brief deserialize GetPlayersInRoomRequest
 * \param buffer buffer of json data
 * \return deserialized GetPlayersInRoomRequest
 */
GetPlayersInRoomRequest JsonRequestPacketDeserializer::deserializeGetPlayersInRoomRequest(const Buffer& buffer)
{
	string bufferStr = Helper::getStringFromBuffer(buffer);

	json j = json::parse(bufferStr);

	GetPlayersInRoomRequest request;
	request.roomId = j["roomId"];
	return request;
}

/**
 * \brief dererialize CreateRoomRequest
 * \param buffer buffer of json data
 * \return deserialized CreateRoomRequest
 */
JoinRoomRequest JsonRequestPacketDeserializer::deserializeJoinRoomRequest(const Buffer& buffer)
{
	string bufferStr = Helper::getStringFromBuffer(buffer);

	json j = json::parse(bufferStr);

	JoinRoomRequest request;
	request.roomId = j["roomId"];
	return request;
}


