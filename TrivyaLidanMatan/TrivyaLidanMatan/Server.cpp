#include "Server.h"

Server::Server(IDataBase* db) : m_database(db), m_handlerFactory(db), m_communicator(Communicator(m_handlerFactory))
{
	m_database->open();
}

/**
 * \brief The function will start the server, start listening to incoming connections and will handle them, whenever EXIT is typed the server will just be stopped
 */
void Server::run()
{
	// create new thread for client	and detach from it
	std::thread communicatorThread(&Communicator::startHandleRequests, m_communicator);
	communicatorThread.detach();

	while(true)
	{
		std::string input;
		std::cin >> input;
		if (input == "EXIT")
		{
			break;
		}
	}
	std::cout << "Leaving. . . ." << std::endl;
}
