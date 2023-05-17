#pragma once

#include <map>


using std::map;

#include "Room.h"


class RoomManager
{
public:

	RoomManager();

	void createRoom(const LoggedUser& user, const RoomData& roomData);
	void deleteRoom(unsigned int id);
	unsigned int getRoomState(int id);
	vector<RoomData> getRooms();
	Room& getRoom(int id);

private:
	map<unsigned int,Room> m_rooms;

};

