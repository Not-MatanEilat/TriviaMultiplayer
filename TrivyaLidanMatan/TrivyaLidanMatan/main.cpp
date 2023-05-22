#pragma comment (lib, "ws2_32.lib")

#include "JsonResponsePacketSerializer.h"
#include "WSAInitializer.h"
#include "Server.h"

int main()
{
	WSAInitializer wsaInit;
	SqliteDataBase db;


	GetRoomsResponse rooms;
	rooms.status = 1;
	RoomData r1;
	r1.id = 1;
	r1.isActive = 1;
	r1.maxPlayers = 2;
	r1.name = "room1";
	r1.numOfQuestionsInGame = 3;
	r1.timePerQuestion = 10;

	rooms.rooms.push_back(r1);

	RoomData r2;
	r2.id = 2;
	r2.isActive = 1;
	r2.maxPlayers = 2;
	r2.name = "room2";
	r2.numOfQuestionsInGame = 3;
	r2.timePerQuestion = 10;
	r2.isActive = 1;

	rooms.rooms.push_back(r2);

	RoomData r3;
	r3.id = 2;
	r3.isActive = 1;
	r3.maxPlayers = 2;
	r3.name = "room2";
	r3.numOfQuestionsInGame = 3;
	r3.timePerQuestion = 10;
	r3.isActive = 1;

	rooms.rooms.push_back(r3);


	JsonResponsePacketSerializer::serializeResponse(rooms);

	Server server(&db);
	server.run();
	return 0;

}