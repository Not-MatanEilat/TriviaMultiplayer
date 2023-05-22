#include "MenuRequestHandler.h"

#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

/**
 * \brief The constructor for the MenuRequestHandler
 * \param handlerFactory the factory for the class
 */
MenuRequestHandler::MenuRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser user) : m_handlerFactory(handlerFactory), m_user(user), m_roomManager(handlerFactory.getRoomManager()), m_statisticsManager(handlerFactory.getStatisticsManager())
{
}

/**
 * \brief Checks if the request is relevant to the handler (for now, always true)
 * \param info the request info
 * \return for now always true
 */
bool MenuRequestHandler::isRequestRelevant(RequestInfo info)
{
	return true;
}


/**
 * \brief Handlers the request as the menu
 * \param info the info of request
 * \return The result for request
 */
RequestResult MenuRequestHandler::handleRequest(RequestInfo info)
{
	RequestResult result;
	result.newHandler = this;
	ErrorResponse response;
	response.message = "Request not implemented yet";
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}

RequestResult MenuRequestHandler::getRooms(RequestInfo const& info)
{
	RequestResult result;

	GetRoomResponse response;
	
	response.rooms = m_roomManager.getRooms();
	response.status = SUCCESS;

	result.newHandler = this;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}

RequestResult MenuRequestHandler::getPlayersInRoom(RequestInfo const& info)
{

	GetPlayersInRoomRequest request = JsonRequestPacketDeserializer::deserializeGetPlayersInRoomRequest(info.buffer);

	RequestResult result;

	GetPlayersInRoomResponse response;

	vector<LoggedUser> users = m_handlerFactory.getRoomManager().getRoom(request.roomId).getAllUsers();
	vector<string> usernames;

	for (auto user : users)
	{
		usernames.push_back(user.getUsername());
	}

	response.players = usernames;
	response.status = SUCCESS;

	result.newHandler = this;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}

RequestResult MenuRequestHandler::getHighScore(RequestInfo const& info)
{
	RequestResult result;

	GetHighscoreResponse response;

	response.highscores = m_statisticsManager.getHighScore();
	response.status = SUCCESS;

	result.newHandler = this;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}

RequestResult MenuRequestHandler::getPersonalStats(RequestInfo const& info)
{
	RequestResult result;

	GetPersonalStatsResponse response;

	response.statistics = m_statisticsManager.getUserStatistics(m_user.getUsername());
	response.status = SUCCESS;

	result.newHandler = this;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}

RequestResult MenuRequestHandler::joinRoom(RequestInfo const& info)
{
	JoinRoomRequest request = JsonRequestPacketDeserializer::deserializeJoinRoomRequest(info.buffer);

	RequestResult result;

	JoinRoomResponse response;

	m_handlerFactory.getRoomManager().joinRoom(m_user ,request.roomId);

	response.status = SUCCESS;

	result.newHandler = this;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}


