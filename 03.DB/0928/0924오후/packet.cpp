//packet.cpp

#include "std.h"

//flag, name, balance
PACK_ACCOUNTINFO pack_SetInsertAccount(const ACCOUNT* pacc)
{
	PACK_ACCOUNTINFO info = { 0 };

	info.flag = PACK_INSERTACCOUNT;
	_tcscpy_s(info.name, _countof(info.name), pacc->name);
	info.balance = pacc->balance;

	return info;
}

PACK_GETNAME pack_SetSelectNameToId(TCHAR* name)
{
	PACK_GETNAME info = { 0 };

	info.flag = PACK_SELECTNAMETOID;
	_tcscpy_s(info.name, _countof(info.name), name);

	return info;
}

PACK_ACCOUNTINFO pack_SetSelectAccount(int id)
{
	PACK_ACCOUNTINFO packet = { 0 };

	packet.flag = PACK_SELECTACCOUNT;
	packet.id = id;

	return packet;
}