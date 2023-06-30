#include "AESCryptoLib.h"

/**
 * \brief encrypts a message using the AES algorithm
 * \param m the message to encrypt
 * \return encrypted message
 */
std::string AESCryptoLib::encrypt(std::string m)
{
	std::string cipherText;
	try {
		CryptoPP::CBC_Mode<CryptoPP::AES>::Encryption encryption(_key, CryptoPP::AES::DEFAULT_KEYLENGTH, _iv);
		CryptoPP::StringSource(m, true, new CryptoPP::StreamTransformationFilter(encryption, new CryptoPP::StringSink(cipherText)));
		return base64Encode(cipherText);
	}
	catch (const CryptoPP::Exception& e) {
		std::cerr << "Encryption error: " << e.what() << std::endl;
	}
	return "";
}

/**
 * \brief decrypts a message using the AES algorithm
 * \param m the message to decrypt
 * \return decrypted message
 */
std::string AESCryptoLib::decrypt(std::string m)
{
	std::string decryptedText;
	try {
		CryptoPP::CBC_Mode<CryptoPP::AES>::Decryption decryption(_key, CryptoPP::AES::DEFAULT_KEYLENGTH, _iv);
		CryptoPP::StringSource(base64Decode(m), true, new CryptoPP::StreamTransformationFilter(decryption, new CryptoPP::StringSink(decryptedText)));
		return decryptedText;
	}
	catch (const CryptoPP::Exception& e) {
		std::cerr << "Decryption error: " << e.what() << std::endl;
	}
	return "";
}

/**
 * \brief encodes a string to base64
 * \param input the string to encode
 * \return encoded string
 */
std::string AESCryptoLib::base64Encode(const std::string& input)
{
	std::string encoded;
	CryptoPP::StringSource(input, true, new CryptoPP::Base64Encoder(new CryptoPP::StringSink(encoded)));
	return encoded;
}

/**
 * \brief decodes a string from base64
 * \param input the string to decode
 * \return decoded string
 */
std::string AESCryptoLib::base64Decode(const std::string& input)
{
	std::string decoded;
	CryptoPP::StringSource(input, true, new CryptoPP::Base64Decoder(new CryptoPP::StringSink(decoded)));
	return decoded;
}
