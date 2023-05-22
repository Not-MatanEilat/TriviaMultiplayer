#include "MenuRequestHandler.h"

#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

/**
 * \brief The constructor for the MenuRequestHandler
 * \param handlerFactory the factory for the class
 */
MenuRequestHandler::MenuRequestHandler(RequestHandlerFactory& handlerFactory) : m_handlerFactory(handlerFactory)
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

RequestResult MenuRequestHandler::roomList(RequestInfo const& info)
{
	RequestResult result;

	GetRoomResponse response;
	
	response.rooms = m_handlerFactory.getRoomManager().getRooms();
	response.status = SUCCESS;

	result.newHandler = this;
	result.response = JsonResponsePacketSerializer::serializeResponse(response);
	return result;
}
