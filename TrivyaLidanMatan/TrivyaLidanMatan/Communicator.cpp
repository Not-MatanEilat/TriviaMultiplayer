#include "Communicator.h"

#include "JsonRequestPacketDeserializer.h"

// using static const instead of macros 
static const unsigned short PORT = 8826;
static const unsigned int IFACE = 0;

/**
 * \brief The function will start listening to incoming connections
 */
void Communicator::startHandleRequests()
{

	bindAndListen();

	while (true)
	{
		// the main thread is only accepting clients 
		// and add then to the list of handlers
		TRACE("accepting client...");

		SOCKET client_socket = accept(m_serverSocket, NULL, NULL);
		if (client_socket == INVALID_SOCKET)
			throw std::exception(__FUNCTION__);

		TRACE("Client accepted !");

		// add client to the clients map

		LoginRequestHandler* loginRequestHandler = m_handlerFactory.createLoginRequestHandler();
		m_clients[client_socket] = loginRequestHandler;

		// create new thread for client	and detach from it
		std::thread tr(&Communicator::handleNewClient, this, client_socket);
		tr.detach();
	}
}

/// <summary>
/// The constructor of the communicator, it will create a new socket for the server to listen from later on
/// </summary>
Communicator::Communicator(RequestHandlerFactory& handlerFactory) : m_handlerFactory(handlerFactory)
{
	// this server use TCP. that why SOCK_STREAM & IPPROTO_TCP
	// if the server use UDP we will use: SOCK_DGRAM & IPPROTO_UDP
	m_serverSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (m_serverSocket == INVALID_SOCKET) 
	{
		throw std::runtime_error(__FUNCTION__ " - socket");
	}
}

/**
 * \brief The function will handle a new client - for now sends hello and prints its answer
 * \param clientSocket - the socket of the new client
 */
void Communicator::handleNewClient(SOCKET clientSocket)
{
	Helper::sendData(clientSocket, "Hello");

	try
	{
		while (true)
		{
			int code = Helper::getMessageTypeCode(clientSocket);
			int len = Helper::getIntPartFromSocket(clientSocket, 4);
			TRACE("code: " << code << " len: " << len);
			Buffer msg = Helper::getBufferPartFromSocket(clientSocket, len);
			RequestInfo requestInfo;
			requestInfo.requestId = code;
			requestInfo.buffer = msg;
			requestInfo.receivalTime = clock();
			RequestResult result;
			if (m_clients[clientSocket]->isRequestRelevant(requestInfo))
			{
				result = m_clients[clientSocket]->handleRequest(requestInfo);
				m_clients[clientSocket] = result.newHandler;
			}
			else
			{
				ErrorResponse response;
				response.message = "Invalid message code for this state";

				result.response = JsonResponsePacketSerializer::serializeResponse(response);
			}
			Helper::sendData(clientSocket, result.response);
		}
	}
	catch (const std::exception& e)
	{
		std::cout << "Connection lost: " << e.what() << std::endl;
	}
	
}

/**
 * \brief This function will bind the socket to the port and will start listening to incoming connections
 */
void Communicator::bindAndListen()
{
	struct sockaddr_in sa = { 0 };

	sa.sin_port = htons(PORT); // port that server will listen for
	sa.sin_family = AF_INET;   // must be AF_INET
	sa.sin_addr.s_addr = INADDR_ANY;    // when there are few ip's for the machine. We will use always "INADDR_ANY"

	// Connects between the socket and the configuration (port and etc..)
	if (bind(m_serverSocket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
	{
		throw std::exception(__FUNCTION__ " - bind");
	}

	// Start listening for incoming requests of clients
	if (listen(m_serverSocket, SOMAXCONN) == SOCKET_ERROR)
	{
		throw std::exception(__FUNCTION__ " - listen");
	}
	std::cout << "Listening on port " << PORT << std::endl;
}
