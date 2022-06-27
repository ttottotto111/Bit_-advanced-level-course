//handler.h
#pragma once

#include <Windows.h>
#include <tchar.h>
#include "handler.h"

LRESULT OnCreate(HWND hwnd,WPARAM wParam, LPARAM lParam);
LRESULT OnLButtonDown(HWND hwnd, WPARAM wParam, LPARAM lParam);
LRESULT OnPaint(HWND hwnd, WPARAM wParam, LPARAM lParam);