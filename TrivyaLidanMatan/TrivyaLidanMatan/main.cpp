#pragma comment (lib, "ws2_32.lib")

#include "OTPCryptoAlgorithm.h"
#include "WSAInitializer.h"
#include "Server.h"


int main()
{
	WSAInitializer wsaInit;
	SqliteDataBase db;
	OTPCryptoAlgorithm otp(db);
	ICryptoAlgorithm::testEncyption(db, otp);

	Server server(&db);
	server.run();
	return 0;
}