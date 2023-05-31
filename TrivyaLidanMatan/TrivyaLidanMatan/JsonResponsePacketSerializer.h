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
	unsigned int roomId;
} CreateRoomResponse;

typedef struct CloseRoomResponse
{
	unsigned int status;
} CloseRoomResponse;

typedef struct StartGameResponse
{
	unsigned int status;
} StartGameResponse;

typedef struct GetRoomStateResponse
{
	unsigned int status;
	bool hasGameBegun;
	vector<string> players;
	unsigned int questionCount;
	unsigned int answerTimeout;
} GetRoomStateResponse;

typedef struct LeaveRoomResponse
{
	unsigned int status;
} LeaveRoomResponse;

typedef struct LeaveGameResponse
{
	unsigned int status;
} LeaveGameResponse;

typedef struct GetQuestionResponse
{
	unsigned int status;
	string question;
	map<unsigned int, string> answers;
} GetQuestionResponse;

typedef struct SubmitAnswerResponse
{
	unsigned int status;
	bool correctAnswer;
} SubmitAnswerResponse;

typedef struct PlayerResults
{
	string username;
	unsigned int correctAnswerCount;
	unsigned int wrongAnswerCount;
	unsigned int averageAnswerTime;
} PlayerResults;


typedef struct GetGameResultsResponse
{
	unsigned int status;
	vector<PlayerResults> results;
} GetGameResultsResponse;

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

	static Buffer serializeResponse(const CloseRoomResponse& closeRoomResponse);
	static Buffer serializeResponse(const StartGameResponse& startGameResponse);
	static Buffer serializeResponse(const GetRoomStateResponse& getRoomStateResponse);
	static Buffer serializeResponse(const LeaveRoomResponse& leaveRoomResponse);

	static Buffer serializeResponse(const LeaveGameResponse& leaveGameResponse);
};

