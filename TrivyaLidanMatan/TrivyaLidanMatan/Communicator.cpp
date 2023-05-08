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

		LoginRequestHandler* loginRequestHandler = new LoginRequestHandler();
		m_clients[client_socket] = loginRequestHandler;

		// create new thread for client	and detach from it
		std::thread tr(&Communicator::handleNewClient, this, client_socket);
		tr.detach();
	}
}

/// <summary>
/// The constructor of the communicator, it will create a new socket for the server to listen from later on
/// </summary>
Communicator::Communicator()
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

	while (true)
	{
		int code = Helper::getMessageTypeCode(clientSocket);
		int len = Helper::getIntPartFromSocket(clientSocket, 4);
		string msg = Helper::getStringPartFromSocket(clientSocket, len);
		if (code == LOGIN_CODE)
		{
			LoginRequest loginRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(msg);

			LoginResponse response;
			response.status = 1;

			Buffer buffer = JsonResponsePacketSerializer::serializeResponse(response);
			Helper::sendData(clientSocket, buffer);
		}
		else if (code == SIGNUP_CODE)
		{
			SignupRequest signupRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(msg);

			SignupResponse response;
			response.status = 1;

			Buffer buffer = JsonResponsePacketSerializer::serializeResponse(response);
			Helper::sendData(clientSocket, buffer);
		}
		else
		{
			ErrorResponse errorResponse;
			errorResponse.message = "Invalid message code";

		}
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
