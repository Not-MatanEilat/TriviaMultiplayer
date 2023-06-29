#pragma once
#include "ICryptoAlgorithm.h"
#include "IDataBase.h"

class OTPCryptoAlgorithm :
    public ICryptoAlgorithm
{
public:
	OTPCryptoAlgorithm(IDataBase& db);

	const string TYPE = "OTP";

	string encrypt(string m) override;
	string decrypt(string m) override;
	string decrypt(string m, string key);

	static int getRand(int min, int max);
private:
	IDataBase& _db;
};

