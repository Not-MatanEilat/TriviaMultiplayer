#pragma comment (lib, "ws2_32.lib")

#include "JsonResponsePacketSerializer.h"
#include "WSAInitializer.h"
#include "Server.h"

int main()
{
	WSAInitializer wsaInit;
	SqliteDataBase db;
	Server server(&db);
	server.run();
	return 0;

}