#pragma once
#include <iostream>
#include <io.h>
#include <fstream>
#include <sstream>
#include <string>
#include <exception>
#include <map>
#include <stdexcept>
#include <vector>

#include "sqlite3.h"

using std::cout;
using std::endl;
using std::string;

typedef std::map<string, string> Row;
typedef std::vector<Row> Result;

int callback(void* data, int argc, char** argv, char** azColName);

class Sqlite3DB
{
public:
	Sqlite3DB(const string& dbFileName);
	virtual ~Sqlite3DB();
	bool open();
	virtual void init();
	Result exec(string sqlStatement);
	Result exec(string sqlStatement, std::vector<string>& args);
	Result exec(const char* sqlStatement);
	void close();

	sqlite3* getDb() const;
	string getDbFileName() const;
	int getFileExist() const;
	char* getLastQuery() const;
	Result& getLastResult();

private:

	sqlite3* _db;
	string _dbFileName;
	int _fileExist;
	char* _lastQuery;
	Result _lastResult;
};

