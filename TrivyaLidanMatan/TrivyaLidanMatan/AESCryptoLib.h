#pragma once
#include "ICryptoAlgorithm.h"
#include <iostream>
#include <string>
#include <cryptopp/aes.h>
#include <cryptopp/modes.h>
#include <cryptopp/filters.h>
#include <cryptopp/base64.h>

class AESCryptoLib : public ICryptoAlgorithm {
public:
    AESCryptoLib(const CryptoPP::byte* key, const CryptoPP::byte* iv) : _key(key), _iv(iv) {}

    std::string encrypt(std::string m) override;

    std::string decrypt(std::string m) override;

private:
    static std::string base64Encode(const std::string& input);

    static std::string base64Decode(const std::string& input);

    const CryptoPP::byte* _key;
    const CryptoPP::byte* _iv;
};

