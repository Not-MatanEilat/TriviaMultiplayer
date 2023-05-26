#include "JsonResponsePacketSerializer.h"

/**
 * \brief The function will take an error response and serialize it to a buffer ("message" : error message)
 * \param errorResponse the error response to serialize
 * \return error response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(const ErrorResponse& errorResponse)
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
Buffer JsonResponsePacketSerializer::serializeResponse(const LoginResponse& loginResponse)
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
Buffer JsonResponsePacketSerializer::serializeResponse(const SignupResponse& signupResponse)
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
Buffer JsonResponsePacketSerializer::serializeResponse(const LogoutResponse& logoutResponse)
{
		json j;
	j["status"] = logoutResponse.status;
	Buffer vec = serializeResponseFromJson(LOGOUT_CODE, j);
	return vec;
}

/**
 * \brief The function will take a getRooms response and serialize it to a buffer
 * ("status" : status, "rooms" : ("isActive" : isActive, "name" : name, "maxPlayers" : maxPlayers, "numOfQuestionsInGame" : numOfQuestionsInGame, "timePerQuestion" : timePerQuestion, "id" : id))
 * \param getRoomsResponse the getRooms response to serialize
 * \return getRooms response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(const GetRoomsResponse& getRoomsResponse)
{
	json j;
	j["status"] = getRoomsResponse.status;
	for (auto& roomData : getRoomsResponse.rooms)
	{
		json roomJson;
		roomJson["isActive"] = roomData.isActive;
		roomJson["name"] = roomData.name;
		roomJson["maxPlayers"] = roomData.maxPlayers;
		roomJson["numOfQuestionsInGame"] = roomData.numOfQuestionsInGame;
		roomJson["timePerQuestion"] = roomData.timePerQuestion;
		roomJson["id"] = roomData.id;
		roomJson["currentPlayersAmount"] = roomData.currentPlayersAmount;

		j["rooms"].push_back(roomJson);
	}

	TRACE(j);

	Buffer vec = serializeResponseFromJson(ROOMS_LIST_CODE, j);
	return vec;
}

/**
 * \brief The function will take a getPlayersInRoom response and serialize it to a buffer ("status" : status, "players" : players)
 * \param getPlayersInRoomResponse the getPlayers response to serialize
 * \return getPlayers response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(const GetPlayersInRoomResponse& getPlayersInRoomResponse)
{
	json j;
	j["status"] = getPlayersInRoomResponse.status;
	j["players"] = getPlayersInRoomResponse.players;
	Buffer vec = serializeResponseFromJson(PLAYERS_IN_ROOM_CODE, j);
	return vec;
}

/**
 * \brief The function will take a getHighscore response and serialize it to a buffer ("status" : status, "highscores" : players)
 * \param getHighscoreResposne the getHighscore response to serialize
 * \return getHighscore response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(const GetHighscoreResponse& getHighscoreResponse)
{
	json j;
	j["status"] = getHighscoreResponse.status;
	j["highscores"] = getHighscoreResponse.highscores;
	Buffer vec = serializeResponseFromJson(HIGH_SCORES_CODE, j);
	return vec;
}

/**
 * \brief The function will take a getPersonalStats response and serialize it to a buffer ("status" : status, "statistics" : statistics)
 * \param getPersonalStatsResponse the getPersonalStats response to serialize
 * \return getPersonalStats response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(const GetPersonalStatsResponse& getPersonalStatsResponse)
{
	json j;
	j["status"] = getPersonalStatsResponse.status;
	j["statistics"] = getPersonalStatsResponse.statistics;
	Buffer vec = serializeResponseFromJson(PERSONAL_STATS_CODE, j);
	return vec;
}

/**
 * \brief The function will take a joinRoom response and serialize it to a buffer ("status" : status)
 * \param joinRoomResponse the joinRoom response to serialize
 * \return joinRoom response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(const JoinRoomResponse& joinRoomResponse)
{
	json j;
	j["status"] = joinRoomResponse.status;
	Buffer vec = serializeResponseFromJson(JOIN_ROOM_CODE, j);
	return vec;
}

/**
 * \brief The function will take a createRoom response and serialize it to a buffer ("status" : status)
 * \param createRoomResponse the createRoom response to serialize
 * \return createRooms response serialized to a buffer
 */
Buffer JsonResponsePacketSerializer::serializeResponse(const CreateRoomResponse& createRoomResponse)
{
	json j;
	j["status"] = createRoomResponse.status;
	Buffer vec = serializeResponseFromJson(CREATE_ROOM_CODE, j);
	return vec;
}


























