
//handler.h
#pragma once

#include <Windows.h>
#include <tchar.h>

LRESULT OnCreate(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnLButtonDown(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnPaint(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnApply_Position(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnApply_Color(HWND hwnd, WPARAM wParam, LPARAM lParam);