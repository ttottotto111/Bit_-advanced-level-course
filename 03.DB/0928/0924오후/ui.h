#pragma once

void ui_GetAccount(HWND hDlg, ACCOUNT* pacc);
void ui_GetSelectName(HWND hDlg, TCHAR* name);

void ui_SetComboBox(int count, int* ids);
void ui_SelectAccountPrint(PACK_ACCOUNTINFO* pacc);

int ui_GetId(HWND hDlg);