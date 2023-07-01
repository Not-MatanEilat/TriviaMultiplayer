#pragma once
#include "ICryptoAlgorithm.h"
#include <iostream>
#include <string>
#include <cryptopp/aes.h>
#include <cryptopp/modes.h>
#include <cryptopp/filters.h>
#include <cryptopp/base64.h>
#include <vector>

using std::vector;
using std::string;

class AESCryptoLib : public ICryptoAlgorithm {
public:
    AESCryptoLib(const CryptoPP::byte* key, const CryptoPP::byte* iv);

    string encrypt(string m) override;

    string decrypt(string m) override;

    static string base64Encode(const string& input);

    static string base64Decode(const string& input);

    static string base64EncodeBytes(const CryptoPP::byte* input, size_t length);

    static CryptoPP::byte* base64DecodeBytes(const std::string& input, size_t& outputSize);

private:
    

    const CryptoPP::byte* _key;
    const CryptoPP::byte* _iv;
};

