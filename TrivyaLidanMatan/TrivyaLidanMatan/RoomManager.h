#pragma once

#include <map>


using std::map;

#include "Room.h"


class RoomManager
{
public:

	RoomManager();

	void createRoom(LoggedUser user, RoomData roomData);
	void deleteRoom(int id);
	unsigned int getRoomState(int id);
	vector<RoomData> getRooms();
	Room& getRoom(int id);

private:
	map<int,Room> m_rooms;

};

