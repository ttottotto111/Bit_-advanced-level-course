//control.h

#pragma once

//�����κ��� ���޵� ������ ����
void con_RecvData(TCHAR *buf);

//ȸ������
void con_NewMember(HWND hDlg);
//�α���
void con_Login(HWND hDlg);
//�α׾ƿ�
void con_LogOut(HWND hDlg);
//��������
void con_ConectServer(HWND hDlg);
//������������
void con_DisConnectServer(HWND hDlg);
//����
void con_SendData(HWND hDlg);
//����
void con_SendLongData(HWND hDlg);

//���α׷� ����
void con_Init(HWND hDlg);
//���α׷� ����
void con_Cancel(HWND hDlg);

//��ư�� Ȱ��ȭ / ��Ȱ��ȭ
void SetButtonState(HWND hDlg, BOOL b1, BOOL b2, BOOL b3, BOOL b4, BOOL b5, BOOL b6);
