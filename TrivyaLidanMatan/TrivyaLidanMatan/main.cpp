#pragma comment (lib, "ws2_32.lib")

#include "WSAInitializer.h"
#include "Server.h"

int main()
{
	WSAInitializer wsaInit;
	Server server;
	server.run();
	return 0;
}