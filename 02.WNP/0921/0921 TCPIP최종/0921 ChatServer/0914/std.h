#pragma once

#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
//======================= 소켓 관련 h =================================
#include <WinSock2.h>	
#pragma comment(lib, "ws2_32.lib")  
#include <ws2tcpip.h>
#include <process.h>	//thread 선언부 
#include <vector>
#include <tchar.h>
using namespace std;
//======================================================================

#include "packet.h"
#include "app.h"
#include "control.h"
#include "wbserver.h"


