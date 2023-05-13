#pragma once


#include "Communicator.h"
#include <thread>

class Server
{
public:
	Server(IDataBase* db);

	void run();
private:
	Communicator m_communicator;
	IDataBase* m_database;
	RequestHandlerFactory m_handlerFactory;
};

