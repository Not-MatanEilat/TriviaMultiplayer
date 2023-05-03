#include "Communicator.h"

// using static const instead of macros 
static const unsigned short PORT = 8826;
static const unsigned int IFACE = 0;

/**
 * \brief The function will start listening to incoming connections
 */
void Communicator::startHandleRequests()
{
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

/**
 * \brief The function will handle a new client - for now sends hello and prints its answer
 * \param clientSocket - the socket of the new client
 */
void Communicator::handleNewClient(SOCKET clientSocket)
{
	Helper::sendData(clientSocket, "Hello");

	std::cout << Helper::getIntPartFromSocket(clientSocket, 5) << std::endl;
}

/**
 * \brief This function will bind the socket to the port and will start listening to incoming connections
 */
void Communicator::bindAndListen()
{
	struct sockaddr_in sa = { 0 };
	sa.sin_port = htons(PORT);
	sa.sin_family = AF_INET;
	sa.sin_addr.s_addr = IFACE;
	// again stepping out to the global namespace
	if (::bind(m_serverSocket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - bind");
	TRACE("binded");

	if (::listen(m_serverSocket, SOMAXCONN) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - listen");
	TRACE("listening...");
}
