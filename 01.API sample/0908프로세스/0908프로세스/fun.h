//fun.h
#pragma once

void fun_WinExec(HWND hDlg);
void fun_CreateProcess(HWND hDlg);
void fun_ListBoxPrint(HWND hDlg);
void fun_List(HWND hDlg, WPARAM wParam);
void fun_ProcessInfoPrint(HWND hDlg, int pid);
void fun_TerminateProcess(HWND hDlg);
void fun_ExitCodeProcess(HWND hDlg, HANDLE phandle);
