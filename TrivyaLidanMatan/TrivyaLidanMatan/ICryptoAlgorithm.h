#pragma once
#include <string>
using std::string;

class ICryptoAlgorithm
{
public:
	virtual ~ICryptoAlgorithm() = default;
	virtual string encrypt(string m) = 0;
	virtual string decrypt(string m) = 0;

	bool testEncryptDecrypt(const string& m);
};

