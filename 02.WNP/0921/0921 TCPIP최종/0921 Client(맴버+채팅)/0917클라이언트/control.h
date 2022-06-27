//control.h

#pragma once

//서버로부터 전달된 데이터 수신
void con_RecvData(TCHAR *buf);

//회원가입
void con_NewMember(HWND hDlg);
//로그인
void con_Login(HWND hDlg);
//로그아웃
void con_LogOut(HWND hDlg);
//서버연결
void con_ConectServer(HWND hDlg);
//서버연결해제
void con_DisConnectServer(HWND hDlg);
//전송
void con_SendData(HWND hDlg);
//전송
void con_SendLongData(HWND hDlg);

//프로그램 시작
void con_Init(HWND hDlg);
//프로그램 종료
void con_Cancel(HWND hDlg);

//버튼의 활성화 / 비활성화
void SetButtonState(HWND hDlg, BOOL b1, BOOL b2, BOOL b3, BOOL b4, BOOL b5, BOOL b6);
