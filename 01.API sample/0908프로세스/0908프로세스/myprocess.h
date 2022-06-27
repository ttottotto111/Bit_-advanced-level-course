//myprocess.h
#pragma once

#include <tchar.h>

typedef struct tagMYPROCESS
{
	TCHAR	name[20];
	int		pid;
	HANDLE   phandle;

}MYPROCESS;
