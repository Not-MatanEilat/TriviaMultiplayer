#include "Helper.h"
#include <iostream>
#include <fstream>
#include <iomanip>
#include <sstream>

// recieves the type code of the message from socket (3 bytes)
// and returns the code. if no message found in the socket returns 0 (which means the client disconnected)
int Helper::getMessageTypeCode(const SOCKET sc)
{
	Buffer msg = getBufferPartFromSocket(sc, 1);

	if (msg.empty())
		return 0;

	int res = msg[0];
	return  res;
}


void Helper::send_update_message_to_client(const SOCKET sc, const string& file_content, const string& second_username, const string& all_users)
{
	//TRACE("all users: %s\n", all_users.c_str())
	const string code = std::to_string(MT_SERVER_UPDATE);
	const string current_file_size = getPaddedNumber(file_content.size(), 5);
	const string username_size = getPaddedNumber(second_username.size(), 2);
	const string all_users_size = getPaddedNumber(all_users.size(), 5);
	const string res = code + current_file_size + file_content + username_size + second_username + all_users_size + all_users;
	//TRACE("message: %s\n", res.c_str());
	sendData(sc, res);
}

// recieve data from socket according byteSize
// returns the data as int
int Helper::getIntPartFromSocket(const SOCKET sc, const int bytesNum)
{
	Buffer bytes = getBufferPartFromSocket(sc, bytesNum);
	unsigned int len = 0;
	int max = bytesNum * 8 - 8;
	for (int i = bytesNum - 1; i >= 0; --i)
	{
		len |= ((bytes[i]) << (max - i*8));
	}
	return len;
}

// recieve data from socket according byteSize
// returns the data as string
string Helper::getStringPartFromSocket(const SOCKET sc, const int bytesNum)
{
	return getPartFromSocket(sc, bytesNum, 0);
}

// recieve data from socket according byteSize
// returns the data as string
Buffer Helper::getBufferPartFromSocket(const SOCKET sc, const int bytesNum)
{
	if (bytesNum == 0)
	{
		return Buffer();
	}

	char* data = new char[bytesNum + 1];
	int res = recv(sc, data, bytesNum, 0);
	if (res == INVALID_SOCKET)
	{
		std::string s = "Error while recieving from socket: ";
		s += std::to_string(sc);
		delete[] data;
		throw std::exception(s.c_str());
	}
	data[bytesNum] = 0;
	Buffer buffer(data, data + bytesNum);
	delete[] data;
	return buffer;
}

// return string after padding zeros if necessary
string Helper::getPaddedNumber(const int num, const int digits)
{
	std::ostringstream ostr;
	ostr << std::setw(digits) << std::setfill('0') << num;
	return ostr.str();

}

string Helper::getStringFromBuffer(const Buffer& buffer)
{
	return string(buffer.begin(), buffer.end());
}

// recieve data from socket according byteSize
// this is private function
std::string Helper::getPartFromSocket(const SOCKET sc, const int bytesNum)
{
	return getPartFromSocket(sc, bytesNum, 0);
}

// send data to socket
// this is private function
void Helper::sendData(const SOCKET sc, const std::string message)
{
	const char* data = message.c_str();

	if (send(sc, data, message.size(), 0) == INVALID_SOCKET)
	{
		throw std::exception("Error while sending message to client");
	}
}

// send data to socket
// this is private function
void Helper::sendData(const SOCKET sc, const Buffer message)
{
	const char* data = (char*) message.data();

	if (send(sc, data, message.size(), 0) == INVALID_SOCKET)
	{
		throw std::exception("Error while sending message to client");
	}
}

std::string Helper::getPartFromSocket(const SOCKET sc, const int bytesNum, const int flags)
{
	if (bytesNum == 0)
	{
		return "";
	}

	char* data = new char[bytesNum + 1];
	int res = recv(sc, data, bytesNum, flags);
	if (res == INVALID_SOCKET)
	{
		std::string s = "Error while recieving from socket: ";
		s += std::to_string(sc);
		throw std::exception(s.c_str());
	}
	data[bytesNum] = 0;
	std::string received(data);
	delete[] data;
	return received;
}
