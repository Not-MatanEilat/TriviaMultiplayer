#include "OTPCryptoAlgorithm.h"
#include <random>

OTPCryptoAlgorithm::OTPCryptoAlgorithm(IDataBase& db): _db(db)
{
}

/**
 * \brief encrypts a message using the OTP algorithm
 * \param m the message to encrypt
 * \return encrypted message
 */
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

/**
 * \brief decrypts a message using the OTP algorithm
 * \param m the message to decrypt
 * \return decrypted message
 */
string OTPCryptoAlgorithm::decrypt(string m)
{
	string key = _db.getSecurityKey(m);
	return decrypt(m, key);
}

/**
 * \brief decrypts a message using the OTP algorithm
 * \param m the message to decrypt
 * \param key the key
 * \return decrypted message
 */
string OTPCryptoAlgorithm::decrypt(string m, string key)
{
	for (int i = 0; i < m.size(); i++)
	{
		m[i] = m[i] ^ key[i];
	}
	return m;
}

/**
 * \brief generates a random number between min and max
 * \param min minimum value
 * \param max maximum value
 * \return random number between min and max
 */
int OTPCryptoAlgorithm::getRand(int min, int max)
{
	std::random_device rd;
	std::mt19937 mt(rd());
	std::uniform_int_distribution<int> dist(min, max);
	return dist(mt);
}
