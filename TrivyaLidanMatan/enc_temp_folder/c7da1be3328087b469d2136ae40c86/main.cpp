#pragma comment (lib, "ws2_32.lib")

#include "JsonResponsePacketSerializer.h"
#include "WSAInitializer.h"
#include "Server.h"

int main()
{
	WSAInitializer wsaInit;
	SqliteDataBase db;
	Server server(&db);


	GetRoomsResponse response;
	response.status = 1;
	vector<string> rooms;
	rooms.push_back("room1");
	rooms.push_back("room2");
	rooms.push_back("room3");
	rooms.push_back("room4");

	response.rooms = rooms;

	JsonResponsePacketSerializer::serializeResponse(response);

	server.run();
	return 0;

}