//std.h
#pragma once

//-------------------------------------------------------------------
#define WIN32_LEAN_AND_MEAN
//h���� �浹ó�� Windows.h, Winsock2.h ���������� ������ Ű���� ����
//-------------------------------------------------------------------

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 
#include <stdio.h>
//----------------Winsock���� h------------------
#include <WinSock2.h>	
#pragma comment(lib, "ws2_32.lib")  
#include <ws2tcpip.h>
#include <process.h>
#include "packet.h"
#include "wbclient.h"
//-----------------------------------------------


#include "resource.h"
#include "handler.h"
#include "control.h"
#include "newmemberdlg.h"