using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindApplicationUIElementsDesktopApp
{
    public class Hooks
    {

        public static Dictionary<string, int> UnInstallResults = new Dictionary<string, int>();
        //CallWndProc | GetMsgProc | KeyboardProc | LowLevelKeyboardProc | MouseProc | LowLevelMouseProc | 
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr LPARAM);

        public static int WndProc = 0;
        public static int MsgProc = 0;
        public static int KbProc = 0;
        public static int KbLLProc = 0;
        public static int MProc= 0;
        public static int MLLProc = 0;
        public static uint MLLProc1 = 0;


        public static IntPtr RunningDLLInstance = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);
        


        private static HookProc WndHookProcedure;
        private static HookProc MsgHookProcedure;
        private static HookProc KbHookProcedure;
        private static HookProc KbLLHookProcedure;
        private static HookProc MouseHookProcedure;
        private static HookProc MouseLLHookProcedure;


        public static void InstallHooks()
        {
            WndHookProcedure = new HookProc(CallWndProc);
            MsgHookProcedure = new HookProc(GetMsgProc);
            KbHookProcedure = new HookProc(KeyboardProc);
            KbLLHookProcedure = new HookProc(LowLevelKeyboardProc);
            MouseHookProcedure = new HookProc(MouseProc);
            MouseLLHookProcedure = new HookProc(LowLevelMouseProc);

            //WndProc = WinAPIs.SetWindowsHookEx(WindowsHookConstans.WH_CALLWNDPROC, WndHookProcedure, RunningDLLInstance, Thread.CurrentThread.ManagedThreadId);
            //if (WndProc == 0)
            //{
            //    int errorCode = Marshal.GetLastWin32Error();
            //    WinAPIs.UnhookWindowsHookEx(WndProc);
            //    throw new Win32Exception(errorCode);
            //}
            //MsgProc = WinAPIs.SetWindowsHookEx(Constants.WindowsHookConstans.WH_GETMESSAGE, MsgHookProcedure, RunningDLLInstance, 0);
            //if (MsgProc == 0)
            //{
            //    int errorCode = Marshal.GetLastWin32Error();
            //    WinAPIs.UnhookWindowsHookEx(MsgProc);
            //    throw new Win32Exception(errorCode);
            //}
            //KbProc = WinAPIs.SetWindowsHookEx(WindowsHookConstans.WH_KEYBOARD, KbHookProcedure, RunningDLLInstance, 0);
            //if (KbProc == 0)
            //{
            //    int errorCode = Marshal.GetLastWin32Error();
            //    WinAPIs.UnhookWindowsHookEx(KbProc);
            //    throw new Win32Exception(errorCode);
            //}
            //KbLLProc = WinAPIs.SetWindowsHookEx(Constants.WindowsHookConstans.WH_KEYBOARD_LL, KbLLHookProcedure, RunningDLLInstance, 0);
            //if (KbLLProc == 0)
            //{
            //    int errorCode = Marshal.GetLastWin32Error();
            //    WinAPIs.UnhookWindowsHookEx(KbLLProc);
            //    throw new Win32Exception(errorCode);
            //}
            //MProc = WinAPIs.SetWindowsHookEx(WindowsHookConstans.WH_MOUSE, MouseHookProcedure, RunningDLLInstance, 0);
            //if (MProc == 0)
            //{
            //    int errorCode = Marshal.GetLastWin32Error();
            //    WinAPIs.UnhookWindowsHookEx(MProc);
            //    throw new Win32Exception(errorCode);
            //}
            MLLProc = WinAPIs.SetWindowsHookEx(Constants.WindowsHookConstans.WH_MOUSE_LL, MouseLLHookProcedure, RunningDLLInstance, 0);
            //MLLProc1 = (uint)WinAPIs.SetWindowsHookExNative(MouseHookProcedure, (uint)Constants.WindowsHookConstans.WH_MOUSE_LL, WinAPIs.GetCurrentThreadId());
            if (MLLProc == 0)
            {
                int errorCode = Marshal.GetLastWin32Error();
                WinAPIs.UnhookWindowsHookEx(MLLProc);
                throw new Win32Exception(errorCode);
            }

        }

        public static void UnInstallHooks()
        {
            UnInstallResults.Add("WndProc", WinAPIs.UnhookWindowsHookEx(WndProc));
            UnInstallResults.Add("MsgProc", WinAPIs.UnhookWindowsHookEx(MsgProc));
            UnInstallResults.Add("KbProc", WinAPIs.UnhookWindowsHookEx(KbProc));
            UnInstallResults.Add("KbLLProc", WinAPIs.UnhookWindowsHookEx(KbLLProc));
            UnInstallResults.Add("MProc", WinAPIs.UnhookWindowsHookEx(MProc));
            UnInstallResults.Add("MLLProc", WinAPIs.UnhookWindowsHookEx(MLLProc));
            UnInstallResults.Add("MLLProc1",(int) WinAPIs.UninitializeHook(MLLProc1));


        }

        public static int CallWndProc(int nCode, IntPtr wParam, IntPtr LPARAM)
        {
            ProcStructs.CWPSTRUCT cWPSTRUCT = (ProcStructs.CWPSTRUCT)Marshal.PtrToStructure(LPARAM, typeof(ProcStructs.CWPSTRUCT));


            Console.WriteLine("CallWndProc Invoked");
            return (int)WinAPIs.CallNextHookEx(RunningDLLInstance, nCode, wParam, LPARAM);

        }
        public static  int GetMsgProc(int nCode, IntPtr wParam, IntPtr LPARAM)
        {
            Console.WriteLine("GetMsgProc Invoked");
            return (int)WinAPIs.CallNextHookEx(RunningDLLInstance, nCode, wParam, LPARAM);
        }
        public static  int KeyboardProc(int nCode, IntPtr wParam, IntPtr LPARAM)
        {
            Console.WriteLine("KeyboardProc Invoked");
            return (int)WinAPIs.CallNextHookEx(RunningDLLInstance, nCode, wParam, LPARAM);
        }
        public static int LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr LPARAM)
        {
            ProcStructs.KBDLLHOOKSTRUCT kBDLLHOOKSTRUCT = (ProcStructs.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(LPARAM, typeof(ProcStructs.KBDLLHOOKSTRUCT));

            Console.WriteLine("LowLevelKeyboardProc Invoked");
            return (int)WinAPIs.CallNextHookEx(RunningDLLInstance, nCode, wParam, LPARAM);
        }
        public static int MouseProc(int nCode, IntPtr wParam, IntPtr LPARAM)
        {
            Console.WriteLine("MouseProc Invoked");

            return (int)WinAPIs.CallNextHookEx(RunningDLLInstance, nCode, wParam, LPARAM);
        }

        public static int LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr LPARAM)
        {
            ProcStructs.MouseLLHookStruct mouseLLHookStruct = (ProcStructs.MouseLLHookStruct)Marshal.PtrToStructure(LPARAM, typeof(ProcStructs.MouseLLHookStruct));
            MouseButtons button = MouseButtons.None;
            switch (wParam.ToInt32())
            {
                case Constants.MouseEvents.WM_MOUSEMOVE:
                    button = MouseButtons.None;

                    MouseEventArgs e2 = new MouseEventArgs(
                                                                      button,
                                                                      1,
                                                                      mouseLLHookStruct.pt.X,
                                                                      mouseLLHookStruct.pt.Y,
                                                                      0);
                    OnMouseMovement(null, e2);
                    break;

                //case WM_MOUSEWHEEL:
                //    short zDelta = (short)(mhs.mouseData >> 16);
                //    MouseKeyboardEventHandler.MouseWheel(left, top, zDelta);
                //    break;

                //case WM_LBUTTONDOWN:
                //    MouseKeyboardEventHandler.LeftMouseDown(left, top);
                //    break;

                //case WM_LBUTTONUP:
                //    MouseKeyboardEventHandler.LeftMouseUp(left, top);
                //    break;
                case Constants.MouseEvents.WM_RBUTTONDOWN:
                    button = MouseButtons.Right;
                    MouseEventArgs e = new MouseEventArgs(
                                                  button,
                                                  1,
                                                  mouseLLHookStruct.pt.X,
                                                  mouseLLHookStruct.pt.Y,
                                                  0);
                    OnMouseActivity(null,e);
                    return -1;
                case Constants.MouseEvents.WM_LBUTTONDOWN:
                    button = MouseButtons.Left;
                    MouseEventArgs e1 = new MouseEventArgs(
                                                  button,
                                                  1,
                                                  mouseLLHookStruct.pt.X,
                                                  mouseLLHookStruct.pt.Y,
                                                  0);

                    OnMouseActivity(null, e1);
                    return -1;
                    
            }
            return (int)WinAPIs.CallNextHookEx(RunningDLLInstance, nCode, wParam, LPARAM);
        }


        #region eventHandles
        public static event MouseEventHandler OnMouseActivity;

        public static event MouseEventHandler OnMouseMovement;


        #endregion

    }
}
