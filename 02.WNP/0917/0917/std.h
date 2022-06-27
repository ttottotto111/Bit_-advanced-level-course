//std.h
#pragma once

//-------------------------------------------------------------------
#define WIN32_LEAN_AND_MEAN
//h파일 충돌처리 Windows.h, Winsock2.h 내부적으로 동일한 키워드 정의
//-------------------------------------------------------------------

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//범용타입 사용을 위한 h 
#include <stdio.h>
//----------------Winsock관련 h------------------
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