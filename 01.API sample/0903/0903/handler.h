//handler.h
//�޽��� �ڵ鷯 �Լ� : �޽����� �߻��Ǿ��� �� ȣ��Ǵ� �Լ� 
//�̸� : On+�޽�����

#pragma once
//1
LRESULT OnCreate(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnDestroy(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnTimer(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnPaint(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnLButtonDown(HWND hwnd, WPARAM wParam, LPARAM lParam);

//2
LRESULT OnCommand(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnMouseMove(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnIninMenuPopup(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnPaint1(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnContextMenu(HWND hwnd, WPARAM wParam, LPARAM lParam);

//3
LRESULT OnCreate1(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnCommand1(HWND hwnd, WPARAM wParam, LPARAM lParam);

