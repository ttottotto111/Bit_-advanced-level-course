//cal.h
#pragma once

#ifdef DLL_SOURCE
#define DLLFUNC __declspec(dllexport) 
#else
#define DLLFUNC __declspec(dllimport)
#endif

extern "C" DLLFUNC float add(int n1, int n2);
extern "C" DLLFUNC float sub(int n1, int n2);
extern "C" DLLFUNC float mul(int n1, int n2);
extern "C" DLLFUNC float div(int n1, int n2);

