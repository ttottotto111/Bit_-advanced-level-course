//control.h
#pragma once

void con_Init(HWND hDlg);
void con_Exit(HWND hDlg);
void con_Connect(HWND hDlg);

void con_InsertAccount(HWND hDlg);
void AckInsertAccount_S(PACK_ACCOUNTINFO* pacc);
void AckInsertAccount_F(PACK_ACCOUNTINFO* pacc);

void con_RecvData(TCHAR* buf);

void con_SelectAccount(HWND hDlg);
void AckSelectNameToId_S(PACK_GETNAME* pacc);
void AckSelectNameToId_F(PACK_GETNAME* pacc);

void con_NotifyComboBox(HWND hDlg, WPARAM wParam);
void AckSelectNameToAccount_S(PACK_ACCOUNTINFO* pacc);
void AckSelectNameToAccount_F(PACK_ACCOUNTINFO* pacc);