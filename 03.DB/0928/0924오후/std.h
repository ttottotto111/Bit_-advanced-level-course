//std.h

#pragma once

//--------------------------------------------------------------
#define WIN32_LEAN_AND_MEAN
// h���� �浹 ó�� Windows.h , Winsock2.h ���������� ������ Ű���� ����
//----------------------------------------------------------------

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>	
#include <stdlib.h>
#include "resource.h"
//---------------------- Winsock���� h ------------------------
#include <stdio.h>
#include <WinSock2.h>	
#pragma comment(lib, "ws2_32.lib")  
#include <ws2tcpip.h>
#include <process.h>
#include<wtypes.h> 
#include "wbclient.h"
//-------------------------------------------------------------

#include "account.h"
#include "packet.h"
#include "handler.h"
#include "control.h"
#include "ui.h"
