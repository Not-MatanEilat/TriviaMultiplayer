#include "RoomAdminRequestHandler.h"

#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

/**
 * \brief The constructor for RoomAdminRequestHandler
 * \param handlerFactory The factory handler
 * \param user the user that has created the room that is in
 * \param room the room the user has already created
 */
RoomAdminRequestHandler::RoomAdminRequestHandler(RequestHandlerFactory& handlerFactory, LoggedUser user, Room& room) : m_handlerFactory(handlerFactory), m_user(user), m_room(room), m_roomManager(handlerFactory.getRoomManager())
{

}



/**
 * \brief Checks if the given request is relevant to the handler
 * \param info the request info given
 * \return True or False
 */
bool RoomAdminRequestHandler::isRequestRelevant(RequestInfo info)
{
	int code = info.requestId;
	return code == CLOSE_ROOM_CODE || code == ROOM_STATE_CODE || code == START_GAME_CODE;
}

/**
 * \brief The function will handle the admin user of the current room
 * \param info the info of request
 * \return the result for request
 */
RequestResult RoomAdminRequestHandler::handleRequest(RequestInfo info)
 {
	int code = info.requestId;
	RequestResult result;
	try
	{
		if (code == CLOSE_ROOM_CODE)
		{
			result = closeRoom(info);
		}
		else if (code == ROOM_STATE_CODE)
		{
			result = getRoomState(info);
		}
		else if (code == START_GAME_CODE)
		{
			result = startGame(info);
		}
	}
	catch (const std::exception& e)
	{
		ErrorResponse error;
	 	error.message = "Something went wrong: " + std::string(e.what());
	 	TRACE("RoomAdminHandler " << m_user.getUsername() << ": " << error.message)
	 	result.response = JsonResponsePacketSerializer::serializeResponse(error);
	 	result.newHandler = this;
	}

	return result;
 }

void RoomAdminRequestHandler::handleDisconnect()
{
	TRACE("RoomAdminHandler " << m_user.getUsername() << ": disconnected")
	m_roomManager.deleteRoom(m_room.getRoomData().id);
	m_handlerFactory.getLoginManager().logout(m_user.getUsername());
}

/**
 * \brief The function will close the room by deleting it
 * \param info the info of request
 * \return the result for request, error if thre was an error in process
 */
RequestResult RoomAdminRequestHandler::closeRoom(RequestInfo info)
{
	RequestResult result;
	try
	{
		m_roomManager.deleteRoom(m_room.getRoomData().id);

		CloseRoomResponse response;
		response.status = SUCCESS;

		result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
		result.response = JsonResponsePacketSerializer::serializeResponse(response);

		TRACE("User: " + m_user.getUsername() + " has closed the room: " + std::to_string(m_room.getRoomData().id))
	}
	catch (const std::exception& e)
	{
		ErrorResponse error;
		error.message = "Something went wrong: " + std::string(e.what());
		TRACE("RoomAdminHandler " << m_user.getUsername() << ": " << error.message);
		result.response = JsonResponsePacketSerializer::serializeResponse(error);
		result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
	}

	return result;

}

/**
 * \brief The function will return the result with the current state of the room
 * \param info the info of request
 * \return the response of request, if gotten an error then will return an error response
 */
RequestResult RoomAdminRequestHandler::getRoomState(RequestInfo info)
{
	RequestResult result;

	try
	{
		GetRoomStateResponse response;

		response.answerTimeout = m_room.getRoomData().timePerQuestion;
		response.hasGameBegun = m_room.getRoomData().isActive;
		response.players = m_room.getAllUsernames();
		response.questionCount = m_room.getRoomData().numOfQuestionsInGame;
		response.status = SUCCESS;

		result.newHandler = this;
		result.response = JsonResponsePacketSerializer::serializeResponse(response);

		string playersStr = "";
		for (const auto& player : response.players)
		{
			playersStr += player + " ";
		}

		 TRACE("Getting room state by user: " + m_user.getUsername() + "\n"
			"AnswerTimeout: " + std::to_string(response.answerTimeout) + "\n"
			+ "HasGameBegun: " + std::to_string(response.hasGameBegun) + "\n"
			+ "Players: " + std::to_string(response.players.size()) + "\n"
			+ "QuestionCount: " + std::to_string(response.questionCount) + "\n"
			+ "Players: " + playersStr);
	}
	catch (const std::exception& e)
	{
		ErrorResponse error;
		error.message = "Something went wrong: " + std::string(e.what());
		TRACE("RoomAdminHandler " << m_user.getUsername() << ": " << error.message);
		result.newHandler = m_handlerFactory.createMenuRequestHandler(m_user);
		result.response = JsonResponsePacketSerializer::serializeResponse(error);
	}



	return result;
}


/**
 * \brief The function will start the game, if an error happend during that time, will return an error response then
 * \param info the info for request
 * \return the response of request, if gotten an error then will return an error response
 */
RequestResult RoomAdminRequestHandler::startGame(RequestInfo info)
{
	RequestResult result;

	try
	{
		m_room.startGame();

		StartGameResponse response;
		response.status = SUCCESS;

		// stays this for now, soon will change to be the start game handler
		result.newHandler = this;
		result.response = JsonResponsePacketSerializer::serializeResponse(response);
	}
	catch (const std::exception& e)
	{
		ErrorResponse error;
		error.message = "Something went wrong: " + std::string(e.what());
		TRACE("RoomAdminHandler " << m_user.getUsername() << ": " << error.message);
		result.newHandler = this;
		result.response = JsonResponsePacketSerializer::serializeResponse(error);
	}

	return result;
}







