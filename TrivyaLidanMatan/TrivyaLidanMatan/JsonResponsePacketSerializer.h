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

typedef struct GetRoomResponse
{
    unsigned int status;
    vector<RoomData> rooms;
} GetRoomResponse;

typedef struct GetPlayersInRoomResponse
{
    unsigned int status;
    vector<string> players;
} GetPlayersInRoomResponse;

typedef struct GetHighscoreResponse
{
    unsigned int status;
    vector<string> highscores;
} GetRoomResponseetHighscoreResponse;

typedef struct GetPersonalStatusResponse
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
	static Buffer serializeResponse(LoginResponse response);
	static Buffer serializeResponse(SignupResponse response);
	static Buffer serializeResponse(ErrorResponse response);
};

