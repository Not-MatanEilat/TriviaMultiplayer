#include "Server.h"

/**
 * \brief The function will start the server, start listening to incoming connections and will handle them, whenever EXIT is typed the server will just be stopped
 */
void Server::run()
{
	// create new thread for client	and detach from it
	std::thread t1(&Communicator::startHandleRequests, m_communicator);
	t1.detach();

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
