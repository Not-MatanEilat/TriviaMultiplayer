#pragma once


#include <string>
#include <vector>
#include "json.hpp"
#include "Communicator.h"

using std::string;
using std::vector;
using json = nlohmann::json;

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



typedef struct LogoutResponse
{
	unsigned int status;
} LogoutResponse;

typedef struct GetRoomsResponse
{
	unsigned int status;
	vector<RoomData> rooms;
} GetRoomsResponse;

typedef struct GetPlayersInRoomResponse
{
	unsigned int status;
	vector<string> players;
} GetPlayersInRoomResponse;

typedef struct GetHighscoreResponse
{
	unsigned int status;
	vector<string> highscores;
} GetHighscoreResponse;

typedef struct GetPersonalStatsResponse
{
	unsigned int status;
	vector<string> statistics;
} GetPersonalStatsResponse;

typedef struct JoinRoomResponse
{
	unsigned int status;
} JoinRoomResponse;

typedef struct CreateRoomResponse
{
	unsigned int status;
} CreateRoomResponse;

class JsonResponsePacketSerializer
{


public:
	static Buffer serializeResponseFromJson(byte code, json j);
	static Buffer serializeResponse(const LoginResponse& loginResponse);
	static Buffer serializeResponse(const SignupResponse& signupResponse);
	static Buffer serializeResponse(const ErrorResponse& errorResponse);

	static Buffer serializeResponse(const LogoutResponse& logoutResponse);
	static Buffer serializeResponse(const GetRoomsResponse& getRoomsResponse);
	static Buffer serializeResponse(const GetPlayersInRoomResponse& getPlayersInRoomResponse);
	static Buffer serializeResponse(const GetHighscoreResponse& getHighscoreResponse);
	static Buffer serializeResponse(const GetPersonalStatsResponse& getPersonalStatsResponse);
	static Buffer serializeResponse(const JoinRoomResponse& joinRoomResponse);
	static Buffer serializeResponse(const CreateRoomResponse& createRoomResponse);
};

