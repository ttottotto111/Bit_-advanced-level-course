#pragma once

#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>
//======================= ���� ���� h =================================
#include <WinSock2.h>	
#pragma comment(lib, "ws2_32.lib")  
#include <ws2tcpip.h>
#include <process.h>	//thread ����� 
#include <vector>
#include <tchar.h>
using namespace std;
//======================================================================
#include <sql.h>
#include <sqlext.h>

#include "account.h"
#include "packet.h"
#include "app.h"
#include "control.h"
#include "wbserver.h"
#include "wb_db.h"


