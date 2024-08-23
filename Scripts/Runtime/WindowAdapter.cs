using System;
using System.Runtime.InteropServices;

public class WindowAdapter
{

  public static readonly int GWL_STYLE = -20;
  private static readonly uint WS_EX_LAYERED = 0x00080000;
  private static readonly uint WS_EX_TRANSPARENT = 0x00000020;
  public static readonly IntPtr HWND_TOP_MOST = new IntPtr(-1);

  public static uint UNCLICKABLE { get => WS_EX_LAYERED | WS_EX_TRANSPARENT; }
  public static uint CLICKABLE { get => WS_EX_LAYERED; }

  [DllImport("user32.dll")]
  public static extern IntPtr GetActiveWindow();

  [DllImport("user32.dll", SetLastError = true)]
  public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlag);

  [DllImport("dwmapi.dll")]
  public static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins margins);
}