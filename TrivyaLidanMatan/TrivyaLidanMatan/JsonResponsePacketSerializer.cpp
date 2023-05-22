#include "JsonResponsePacketSerializer.h"

/**
 * \brief The function will take an error response and serialize it to a buffer ("message" : error message)
 * \param errorResponse the error response to serialize
 * \return error response serialized to a buffer
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
 * \brief The function will take a login response and serialize it to a buffer ("status" : status)
 * \param loginResponse The login response to serialize
 * \return login response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(LoginResponse loginResponse)
{
	json j;
	j["status"] = loginResponse.status;
	Buffer vec = serializeResponseFromJson(LOGIN_CODE, j);
	return vec;
}

/**
 * \brief The function will take a signup response and serialize it to a buffer ("status" : status)
 * \param signupResponse the signup response to serialize
 * \return signup response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(SignupResponse signupResponse)
{
	json j;
	j["status"] = signupResponse.status;
	Buffer vec = serializeResponseFromJson(SIGNUP_CODE, j);
	return vec;
}

/**
 * \brief The function will take a logout response and serialize it to a buffer ("status" : status)
 * \param logoutResponse the logout response to serialize
 * \return logout response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(LogoutResponse logoutResponse)
{
		json j;
	j["status"] = logoutResponse.status;
	Buffer vec = serializeResponseFromJson(LOGOUT_CODE, j);
	return vec;
}

/**
 * \brief The function will take a getRooms response and serialize it to a buffer ("status" : status, "rooms" : rooms)
 * \param getRoomResponse the getRooms response to serialize
 * \return getRooms response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(GetRoomResponse getRoomResponse)
{
	json j;
	j["status"] = getRoomResponse.status;
	j["rooms"] = getRoomResponse.rooms;
	Buffer vec = serializeResponseFromJson(ROOMS_LIST_CODE, j);
	return vec;
}

/**
 * \brief The function will take a getPlayersInRoom response and serialize it to a buffer ("status" : status, "players" : players)
 * \param getPlayersInRoomResponse the getPlayers response to serialize
 * \return getPlayers response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(GetPlayersInRoomResponse getPlayersInRoomResponse)
{
	json j;
	j["status"] = getPlayersInRoomResponse.status;
	j["players"] = getPlayersInRoomResponse.players;
	Buffer vec = serializeResponseFromJson(PLAYERS_IN_ROOM_CODE, j);
	return vec;
}













