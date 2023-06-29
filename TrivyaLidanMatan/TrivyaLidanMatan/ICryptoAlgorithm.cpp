#include "ICryptoAlgorithm.h"

bool ICryptoAlgorithm::testEncryptDecrypt(const string& m)
{
	return decrypt(encrypt(m)) == m;
}
