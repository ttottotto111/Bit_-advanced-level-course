#ifdef DLL_SOURCE
#define DLLFUNC __declspec(dllexport) 
#else
#define DLLFUNC __declspec(dllimport)
#endif

typedef void (RECVFUN)(char buf, int* size);
extern "C" DLLFUNC void sock_LibInit();
extern "C" DLLFUNC void sock_LibExit();
extern "C" DLLFUNC void sock_CreateSocket();
extern "C" DLLFUNC unsigned int __stdcall sock_ListenThread(void* value);