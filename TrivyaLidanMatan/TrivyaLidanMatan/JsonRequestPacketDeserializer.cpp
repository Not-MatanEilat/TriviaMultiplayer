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
 * \brief dererialize JoinRoomRequest
 * \param buffer buffer of json data
 * \return deserialized JoinRoomRequest
 */
JoinRoomRequest JsonRequestPacketDeserializer::deserializeJoinRoomRequest(const Buffer& buffer)
{
	string bufferStr = Helper::getStringFromBuffer(buffer);

	json j = json::parse(bufferStr);

	JoinRoomRequest request;
	request.roomId = j["roomId"];
	return request;
}


/**
 * \brief deserialize CreateRoomRequest
 * \param  buffer buffer of json data
 * \return deserialized CreateRoomRequest
 */
CreateRoomRequest JsonRequestPacketDeserializer::deserializeCreateRoomRequest(const Buffer& buffer)
{
	string bufferStr = Helper::getStringFromBuffer(buffer);

	json j = json::parse(bufferStr);

	CreateRoomRequest request;
	request.roomName = j["roomName"];
	request.maxUsers = j["maxUsers"];
	request.questionCount = j["questionCount"];
	request.answerTimeout = j["answerTimeout"];
	return request;
}

/**
 * \brief deserialize SubmitAnswerRequest
 * \param buffer buffer of json data
 * \return deserialized SubmitAnswerRequest
 */
SubmitAnswerRequest JsonRequestPacketDeserializer::deserializeSubmitAnswerRequest(const Buffer& buffer)
{
	string bufferStr = Helper::getStringFromBuffer(buffer);

	json j = json::parse(bufferStr);

	SubmitAnswerRequest request;
	request.answerId = j["answerId"];
	return request;
}

/**
 * \brief deserialize AddQuestionRequest
 * \param buffer buffer of json data
 * \return deseriazlized AddQuestionRequest
 */
AddQuestionRequest JsonRequestPacketDeserializer::deserializeAddQuestionRequest(const Buffer& buffer)
{
	string bufferStr = Helper::getStringFromBuffer(buffer);

	json j = json::parse(bufferStr);

	AddQuestionRequest request;
	request.question = j["question"];
	request.correctAns = j["correctAns"];
	request.ans2 = j["ans2"];
	request.ans3 = j["ans3"];
	request.ans4 = j["ans4"];
	return request;
}




