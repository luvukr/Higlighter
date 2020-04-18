using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FindApplicationUIElementsDesktopApp
{
    public class WinAPIs
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetProcessDPIAware();

        [DllImport("User32.Dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(int x, int y);

        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern bool GetPhysicalCursorPos(out Point point);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("USER32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
         CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int SetWindowsHookEx(int idHook, Hooks.HookProc lpfn, IntPtr hMod,int dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx( int idHook, int nCode, int wParam,IntPtr lParam);
        
        [DllImport("user32")]
        private static extern int GetKeyboardState(byte[] pbKeyState);
        
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point pt);

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("kernel32.dll")]
        public static extern uint GetThreadId(IntPtr Thread);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WindowEventHooks.WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern bool UnhookWinEvent(IntPtr hWinEventHook);


        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);

        //[return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowInfo(IntPtr hwnd, ref ProcStructs.WINDOWINFO pwi);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("UIXPathLib.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern uint SetWindowsHookExNative(Hooks.HookProc hProc, uint nHookId, uint nThreadId);

        [DllImport("UIXPathLib.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr UninitializeHook(uint hId);

        [DllImport("UIXPathLib.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        public static extern int GetUiXPath(int left, int top, StringBuilder s, int nMaxCount);

        [DllImport("UIXPathLib.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern void InitUiTreeWalk();

        [DllImport("UIXPathLib.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern void UnInitUiTreeWalk();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hwndAfter, int x, int y, int width, int height, int flags);

        [DllImport("user32.dll")]
        private  static extern int GetMessage(out ProcStructs.MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,uint wMsgFilterMax);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);


        public ProcStructs.WINDOWINFO GetWindowInfo1(IntPtr hWnd)
        {
            ProcStructs.WINDOWINFO wInfo = new ProcStructs.WINDOWINFO();
            wInfo.cbSize = (uint)Marshal.SizeOf(wInfo);

            WinAPIs.GetWindowInfo(hWnd, ref wInfo);
            return wInfo;

        }
        public string GetUiXPath(int x,int y)
        {
            StringBuilder sb = new StringBuilder(4096,Int16.MaxValue);
            try
            {
                WinAPIs.GetUiXPath(x, y, sb, sb.Capacity);

            }
            catch (Exception e)
            {

                throw;
            }
            return sb.ToString();
        }

        public string GetWindowText(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = WinAPIs.GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            WinAPIs.GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        public static ProcStructs.MSG GetMessage(IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax)
        {
            ProcStructs.MSG msg = new ProcStructs.MSG();

            WinAPIs.GetMessage(out msg, hWnd, wMsgFilterMin,wMsgFilterMax);
            return msg;
        }
        public static string GetMainModuleFilepath(int processId)
        {
            string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {
                    ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                    if (mo != null)
                    {
                        return (string)mo["ExecutablePath"];
                    }
                }
            }
            return null;
        }

        public uint GetGUIThreadId(IntPtr hWnd)
        {
            uint threadID = GetWindowThreadProcessId(hWnd, IntPtr.Zero);
            return threadID;
        }
    }
}
