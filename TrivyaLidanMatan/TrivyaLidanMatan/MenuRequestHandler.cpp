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
 * \brief Checks if the request is relevant to the handler
 * \param info the request info
 * \return true if the request is relevant, false otherwise
 */
bool MenuRequestHandler::isRequestRelevant(RequestInfo info)
{
	int code = info.requestId;
	return code == LOGOUT_CODE || code == ROOMS_LIST_CODE || code == PLAYERS_IN_ROOM_CODE || code == HIGH_SCORES_CODE || code == PERSONAL_STATS_CODE || code == JOIN_ROOM_CODE || code == CREATE_ROOM_CODE;
}


/**
 * \brief Handlers the request as the menu
 * \param info the info of request
 * \return The result for request
 */
RequestResult MenuRequestHandler::handleRequest(RequestInfo info)
{
	RequestResult result;
	try
	{
		if (info.requestId == LOGOUT_CODE)
		{
			result = logout(info);
		}
		else if (info.requestId == ROOMS_LIST_CODE)
		{
			result = getRooms(info);
		}
		else if (info.requestId == PLAYERS_IN_ROOM_CODE)
		{
			result = getPlayersInRoom(info);
		}
		else if (info.requestId == HIGH_SCORES_CODE)
		{
			result = getHighScore(info);
		}
		else if (info.requestId == PERSONAL_STATS_CODE)
		{
			result = getPersonalStats(info);
		}
		else if (info.requestId == JOIN_ROOM_CODE)
		{
			result = joinRoom(info);
		}
		else if (info.requestId == CREATE_ROOM_CODE)
		{
			result = createRoom(info);
		}
	}
	catch (const std::exception& e)
	{
		ErrorResponse error;
		error.message = "Something went wrong: " + std::string(e.what());
		TRACE("MenuHandler " << m_user.getUsername() << ": " << error.message)
		result.response = JsonResponsePacketSerializer::serializeResponse(error);
		result.newHandler = this;
	}
	
	return result;
}

/**
 * \brief get the rooms
 * \param info the info of the request
 * \return the request rooms result
 */
RequestResult MenuRequestHandler::logout(RequestInfo const& info)
{
	RequestResult result;

	LogoutResponse response;

	m_handlerFactory.getLoginManager().logout(m_user.getUsername());
	response.status = SUCCESS;

	result.newHandler = m_handlerFactory.createLoginRequestHandler();
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}

/**
 * \brief get the rooms
 * \param info the info of the request
 * \return the request rooms result
 */
RequestResult MenuRequestHandler::getRooms(RequestInfo const& info)
{
	RequestResult result;

	GetRoomsResponse response;
	
	response.rooms = m_roomManager.getRooms();
	response.status = SUCCESS;

	result.newHandler = this;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}

/**
 * \brief get the players in room
 * \param info the info of the request
 * \return the request players result
 */
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

/**
 * \brief get the high score
 * \param info the info of the request
 * \return the high score result
 */
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

/**
 * \brief get the personal stats
 * \param info the info of the request
 * \return the high personal stats
 */
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

/**
 * \brief join the room
 * \param info the info of the request
 * \return the join room result
 */
RequestResult MenuRequestHandler::joinRoom(RequestInfo const& info)
{
	JoinRoomRequest request = JsonRequestPacketDeserializer::deserializeJoinRoomRequest(info.buffer);

	RequestResult result;

	JoinRoomResponse response;

	m_handlerFactory.getRoomManager().joinRoom(m_user ,request.roomId);

	response.status = SUCCESS;

	result.newHandler = m_handlerFactory.createRoomMemberRequestHandler(m_user, m_handlerFactory.getRoomManager().getRoom(request.roomId));
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}

/**
 * \brief create room
 * \param info the info of the request
 * \return the create room result
 */
RequestResult MenuRequestHandler::createRoom(RequestInfo const& info)
{
	CreateRoomRequest request = JsonRequestPacketDeserializer::deserializeCreateRoomRequest(info.buffer);
	
	RequestResult result;

	RoomData roomData;
	roomData.maxPlayers = request.maxUsers;
	roomData.name = request.roomName;
	roomData.timePerQuestion = request.answerTimeout;
	roomData.numOfQuestionsInGame = request.questionCount;
	roomData.currentPlayersAmount = 0;

	int id = 0;
	for (RoomData data : m_roomManager.getRooms())
	{
		if (data.id > id)
		{
			id = data.id;
		}
	}
	roomData.id = id + 1;
	roomData.isActive = false;

	m_roomManager.createRoom(m_user, roomData);


	CreateRoomResponse response;
	response.status = SUCCESS;

	result.newHandler = m_handlerFactory.createRoomAdminRequestHandler(m_user, m_handlerFactory.getRoomManager().getRoom(roomData.id));;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}
