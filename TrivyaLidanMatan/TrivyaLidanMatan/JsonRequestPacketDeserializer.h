#pragma once

#include <string>
#include <vector>

#include "Communicator.h"
#include "JsonResponsePacketSerializer.h"


using std::vector;
using std::string;

typedef struct LoginRequest
{
	string username;
	string password;
} LoginRequest;

typedef struct SignupRequest
{
	string username;
	string password;
	string email;
} SignupRequest;

typedef struct GetPlayersInRoomRequest
{
	unsigned int roomId;
} GetPlayersInRoomRequest;

typedef struct JoinRoomRequest
{
	unsigned int roomId;
} JoinRoomRequest;

typedef struct CreateRoomRequest
{
	string roomName;
	unsigned int maxUsers;
	unsigned int questionCount;
	unsigned int answerTimeout;
} CreateRoomRequest;

typedef struct LogoutRequest
{
	string username;
} LogoutRequest;

typedef struct SubmitAnswerRequest
{
	unsigned int answerId;
} SubmitAnswerRequest;

typedef struct AddQuestionRequest
{
	string question;
	string correctAns;
	string ans2;
	string ans3;
	string ans4;
} AddQuestionRequest;


class JsonRequestPacketDeserializer
{
public:
	static LoginRequest deserializeLoginRequest(const Buffer& buffer);
	static SignupRequest deserializeSignupRequest(const Buffer& buffer);

	static GetPlayersInRoomRequest deserializeGetPlayersInRoomRequest(const Buffer& buffer);
	static JoinRoomRequest deserializeJoinRoomRequest(const Buffer& buffer);
	static CreateRoomRequest deserializeCreateRoomRequest(const Buffer& buffer);

	static SubmitAnswerRequest deserializeSubmitAnswerRequest(const Buffer& buffer);
};

