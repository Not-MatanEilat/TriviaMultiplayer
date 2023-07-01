#include "AESCryptoLib.h"
#include <cryptopp/aes.h>
#include <cryptopp/modes.h>
#include <cryptopp/filters.h>
#include <cryptopp/base64.h>

/**
 * \brief c'tor
 * \param key key for encryption
 * \param iv iv for encryption
 */
AESCryptoLib::AESCryptoLib(const CryptoPP::byte* key, const CryptoPP::byte* iv): _key(key), _iv(iv)
{}

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
	return base64EncodeBytes((CryptoPP::byte *)(input.data()), input.size());
}

/**
 * \brief decodes a string from base64
 * \param input the string to decode
 * \return decoded string
 */
std::string AESCryptoLib::base64Decode(const std::string& input)
{
	size_t size = 0;
	char* decodedBytes = (char* )base64DecodeBytes(input, size);
	return std::string(decodedBytes, decodedBytes + size);
}

/**
 * \brief encodes a string to base64
 * \param value the string to encode
 * \return encoded string
 */
string AESCryptoLib::base64EncodeBytes(const CryptoPP::byte* input, size_t length)
{
	std::string encoded;
	CryptoPP::StringSource soruce(input, length, true, new CryptoPP::Base64Encoder(new CryptoPP::StringSink(encoded)));
	return encoded;
}

/**
 * \brief decodes a string from base64
 * \param value the string to decode
 * \return decoded bytes
 */
CryptoPP::byte* AESCryptoLib::base64DecodeBytes(const std::string& input, size_t& outputSize)
{
	CryptoPP::Base64Decoder decoder;
	decoder.Put((const CryptoPP::byte*)input.data(), input.size());
	decoder.MessageEnd();

	size_t size = decoder.MaxRetrievable();
	CryptoPP::byte* output = new CryptoPP::byte[size];
	decoder.Get(output, size);

	outputSize = size;
	return output;
}
