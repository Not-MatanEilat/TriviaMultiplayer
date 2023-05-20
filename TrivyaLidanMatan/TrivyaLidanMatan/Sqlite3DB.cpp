#include "Sqlite3DB.h"

/**
 * \brief c'tor
 * \param dbFileName database file name
 */
Sqlite3DB::Sqlite3DB(const string& dbFileName): _dbFileName(dbFileName)
{

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
bool Sqlite3DB::open()
{
	if (_db != nullptr)
	{
		return false;
	}
	_fileExist = _access(_dbFileName.c_str(), 0);
	int res = sqlite3_open(_dbFileName.c_str(), &_db);
	// if the database open, return false
	if (res != SQLITE_OK)
	{
		return false;
	}
	if (_fileExist != 0) 
	{
		init();
	}

	// if the database ended up creating, return true
	return true;
}

/**
 * \brief if database doesn't exist init the database
 */
void Sqlite3DB::init()
{
	exec("CREATE TABLE users (username TEXT, password TEXT, email TEXT, PRIMARY KEY (username))");
	exec("CREATE TABLE questions (question TEXT, correctAnswer TEXT, answer2 TEXT, answer3 TEXT, answer4 TEXT, PRIMARY KEY (question))");
	exec("create table Statistics (username TEXT, averageAnswerTime FLOAT, correctAnswers INTEGER, totalAnswers INTEGER, games INTEGER, PRIMARY KEY (username) );");
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
			errMessage = (char*)"SQLITE ERROR";
		}
		throw std::runtime_error(errMessage);
	}
	return _lastResult;
}

/**
 * \brief close database connection
 */
bool Sqlite3DB::close()
{
	bool res = false;
	if (_db != nullptr)
	{
		res = sqlite3_close(_db);
		_db = nullptr;
	}

	// check if the database didn't close properly, if it didn't return false
	if (res != SQLITE_OK)
	{
		return false;
	}

	// if the database closed properly, then just return true
	return true;
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
