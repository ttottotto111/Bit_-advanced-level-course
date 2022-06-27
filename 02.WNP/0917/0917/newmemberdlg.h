//newmemberdlg.h
#pragma once

BOOL CALLBACK NewMemberDlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam);

BOOL new_InitDialog(HWND hDlg, LPARAM lParam);

void new_NewMember(HWND hDlg);