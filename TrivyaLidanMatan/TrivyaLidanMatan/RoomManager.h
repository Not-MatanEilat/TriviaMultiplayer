#pragma once

#include <map>


using std::map;

#include "Room.h"


class RoomManager
{
public:

	RoomManager();

	void createRoom(const LoggedUser& user, const RoomData& roomData);
	void joinRoom(const LoggedUser& user, unsigned int id);
	void leaveRoom(const LoggedUser& user);
	void deleteRoom(unsigned int id);
	unsigned int getRoomState(int id);
	vector<RoomData> getRooms() const;
	vector<RoomData> getWaitingRooms() const;
	Room& getRoom(int id);
	Room& getRoomOfUser(const string& username);
	bool isUserInAnyRoom(const string& username);
	bool doesRoomExist(unsigned int id);

private:
	map<unsigned int,Room> m_rooms;

};

