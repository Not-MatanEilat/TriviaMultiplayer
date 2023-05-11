#include "Sqlite3DB.h"

/**
 * \brief c'tor
 * \param dbFileName database file name
 */
Sqlite3DB::Sqlite3DB(const string& dbFileName): _dbFileName(dbFileName)
{
	open();
}

/**
 * \brief d'tor
 */
Sqlite3DB::~Sqlite3DB()
{
	close();
}

/**
 * \brief open database connection
 */
void Sqlite3DB::open()
{
	if (_db != nullptr)
	{
		return;
	}
	_fileExist = _access(_dbFileName.c_str(), 0);
	int res = sqlite3_open(_dbFileName.c_str(), &_db);
	if (res != SQLITE_OK)
	{
		throw std::runtime_error("Failed to open DB");
	}
	if (_fileExist != 0) 
	{
		init();
	}
}

/**
 * \brief if database doesn't exist init the database
 */
void Sqlite3DB::init()
{
}

/**
 * \brief execute sql statement
 * \param sqlStatement sql statement
 */
Result Sqlite3DB::exec(string sqlStatement)
{
	return exec(sqlStatement.c_str());
}

/**
 * \brief execute sql statement but replace $[index] with arg[index]
 * \param sqlStatement sql statement
 * \param args the arguments
 */
Result Sqlite3DB::exec(string sqlStatement, std::vector<string>& args)
{
	// replace $[index] with arg[index]
	for (int i = 0; i < args.size(); i++)
	{
		string arg = args[i];
		string index = std::to_string(i);
		string replace = "$" + index;
		size_t pos = sqlStatement.find(replace);
		if (pos != string::npos)
		{
			sqlStatement.replace(pos, replace.length(), arg);
		}
	}
	return exec(sqlStatement);
}

/**
 * \brief execute sql statement
 * \param sqlStatement sql statement
 */
Result Sqlite3DB::exec(const char* sqlStatement)
{
	char* errMessage = nullptr;
	_lastQuery = (char*)sqlStatement;
	_lastResult.clear();
	int res = sqlite3_exec(_db, sqlStatement, callback, this, &errMessage);
	if (res != SQLITE_OK)
	{
		if (errMessage == NULL)
		{
			errMessage = "SQLITE ERROR";
		}
		throw std::runtime_error(errMessage);
	}
	return _lastResult;
}

/**
 * \brief close database connection
 */
void Sqlite3DB::close()
{
	if (_db != nullptr)
	{
		sqlite3_close(_db);
		_db = nullptr;
	}
}

/**
 * \brief get database
 * \return the database
 */
sqlite3* Sqlite3DB::getDb() const
{
	return _db;
}

/**
 * \brief get database file name
 * \return the database file name
 */
string Sqlite3DB::getDbFileName() const
{
	return _dbFileName;
}

/**
 * \brief get file exist
 * \return if the file exists
 */
int Sqlite3DB::getFileExist() const
{
	return _fileExist;
}

/**
 * \brief get last query
 * \return the last query
 */
char* Sqlite3DB::getLastQuery() const
{
	return _lastQuery;
}

/**
 * \brief get last result
 * \return the last result
 */
Result& Sqlite3DB::getLastResult()
{
	return _lastResult;
}

/**
 * \brief callback from sqlite3_exec
 * \param data the database
 * \param argc the amount of columns
 * \param argv the values
 * \param azColName the column names
 * \return 0 if worked
 */
int callback(void* data, int argc, char** argv, char** azColName)
{
	Sqlite3DB* db = (Sqlite3DB*)data;
	std::map<string, string> row;
	for (int i = 0; i < argc; i++)
	{
		row[azColName[i]] = argv[i];
	}
	db->getLastResult().push_back(row);
	return 0;
}
