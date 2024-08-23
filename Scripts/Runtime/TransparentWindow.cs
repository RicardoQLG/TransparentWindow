using System;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
#if !UNITY_EDITOR
  private IntPtr m_ActiveWindow;
#endif

  private void Update()
  {
#if !UNITY_EDITOR
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    WindowAdapter.SetWindowLong(m_ActiveWindow, WindowAdapter.GWL_STYLE, Physics.Raycast(ray) ? WindowAdapter.CLICKABLE : WindowAdapter.UNCLICKABLE);
#endif
  }

  private void Start()
  {
#if !UNITY_EDITOR
    Application.runInBackground = true;
    m_ActiveWindow = WindowAdapter.GetActiveWindow();
    Margins margins = new Margins { cxLeftWidth = -1 };
    WindowAdapter.DwmExtendFrameIntoClientArea(m_ActiveWindow, ref margins);
    WindowAdapter.SetWindowPos(m_ActiveWindow, WindowAdapter.HWND_TOP_MOST, 0, 0, 0, 0, 0);
#endif
  }
}