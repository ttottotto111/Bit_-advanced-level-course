//std.h

#pragma once

//--------------------------------------------------------------
#define WIN32_LEAN_AND_MEAN
// h파일 충돌 처리 Windows.h , Winsock2.h 내부적으로 동일한 키워드 정의
//----------------------------------------------------------------

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>	
#include <stdlib.h>
#include "resource.h"
//---------------------- Winsock관련 h ------------------------
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
