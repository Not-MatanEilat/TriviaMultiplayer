#include "ICryptoAlgorithm.h"

bool ICryptoAlgorithm::testEncryptDecrypt(const string& m)
{
	return decrypt(encrypt(m)) == m;
}

void ICryptoAlgorithm::testEncyption(IDataBase& db, ICryptoAlgorithm& algo)
{
	db.open();
	string m = "Hello World!";
	string encrypted = algo.encrypt(m);
	string decrypted = algo.decrypt(encrypted);
	bool work = m == decrypted;
	cout << "Test encrypt decrypt: " << work << endl;
	cout << "m: " << m << endl;
	cout << "encrypted: " << encrypted << endl;
	cout << "decrypted: " << decrypted << endl;
	db.close();
}
