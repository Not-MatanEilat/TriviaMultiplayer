#include "OTPCryptoAlgorithm.h"
#include <random>

OTPCryptoAlgorithm::OTPCryptoAlgorithm(IDataBase& db): _db(db)
{
}

string OTPCryptoAlgorithm::encrypt(string m)
{
	string key;
	for (int i = 0; i < m.length(); i++)
	{
		key += (char)getRand(0, 255);
		m[i] = m[i] ^ key[i];
	}
	_db.setSecurityKey(m, key, TYPE);
	return m;
}

string OTPCryptoAlgorithm::decrypt(string m)
{
	string key = _db.getSecurityKey(m);
	return decrypt(m, key);
}

string OTPCryptoAlgorithm::decrypt(string m, string key)
{
	for (int i = 0; i < m.size(); i++)
	{
		m[i] = m[i] ^ key[i];
	}
	return m;
}

int OTPCryptoAlgorithm::getRand(int min, int max)
{
	std::random_device rd;
	std::mt19937 mt(rd());
	std::uniform_int_distribution<int> dist(min, max);
	return dist(mt);
}
