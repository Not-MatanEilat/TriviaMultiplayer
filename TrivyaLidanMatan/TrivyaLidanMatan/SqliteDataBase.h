#pragma once

#include "IDataBase.h"


class SqliteDataBase : public IDataBase
{
	bool open() override;
	bool close() override;


};

