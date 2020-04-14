using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindApplicationUIElementsDesktopApp
{
    public class WindowEventHooks
    {
        public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        public static Dictionary<string, bool> UnInstallResults = new Dictionary<string, bool>();

        public static IntPtr hCreate;
        public static IntPtr hDestroy;
        public static IntPtr hShow;
        public static IntPtr hSelect;
        public static IntPtr hMinimize;
        public static IntPtr hMinimizeEnd;
        public static IntPtr hMoveSize;
        public static IntPtr hMoveSizeEnd;

        public static WinEventDelegate create = new WinEventDelegate(WinObjectCreateEventProc);
        public static WinEventDelegate destroy = new WinEventDelegate(WinObjectDestroyEventProc);
        public static WinEventDelegate show = new WinEventDelegate(WinObjectShowEventProc);
        public static WinEventDelegate select = new WinEventDelegate(WinObjectSelectionEventProc);
        public static WinEventDelegate minimize = new WinEventDelegate(WinMinimizeEventProc);
        public static WinEventDelegate minimizeEnd = new WinEventDelegate(WinMinimizeEndEventProc);
        public static WinEventDelegate move = new WinEventDelegate(WinMoveSizeEventProc);
        public static WinEventDelegate moveEnd = new WinEventDelegate(WinMoveSizeEndEventProc);

        public static void InstallWindowsEventHooks()
        {

            hCreate = WinAPIs.SetWinEventHook(Constants.EventConstants.EVENT_OBJECT_CREATE, Constants.EventConstants.EVENT_OBJECT_CREATE, Hooks.RunningDLLInstance, create, 0, 0, (uint)(Constants.Contexts.WINEVENT_INCONTEXT| Constants.Contexts.WINEVENT_SKIPOWNPROCESS));
            hDestroy = WinAPIs.SetWinEventHook(Constants.EventConstants.EVENT_OBJECT_DESTROY, Constants.EventConstants.EVENT_OBJECT_DESTROY, Hooks.RunningDLLInstance, destroy, 0, 0, (uint)(Constants.Contexts.WINEVENT_INCONTEXT| Constants.Contexts.WINEVENT_SKIPOWNPROCESS));
            hShow = WinAPIs.SetWinEventHook(Constants.EventConstants.EVENT_OBJECT_SHOW, Constants.EventConstants.EVENT_OBJECT_SHOW, Hooks.RunningDLLInstance, show, 0, 0, (uint)(Constants.Contexts.WINEVENT_INCONTEXT| Constants.Contexts.WINEVENT_SKIPOWNPROCESS));
            hSelect = WinAPIs.SetWinEventHook(Constants.EventConstants.EVENT_OBJECT_SELECTION, Constants.EventConstants.EVENT_OBJECT_SELECTION, Hooks.RunningDLLInstance, select, 0, 0, (uint)(Constants.Contexts.WINEVENT_INCONTEXT| Constants.Contexts.WINEVENT_SKIPOWNPROCESS));
            hMinimize = WinAPIs.SetWinEventHook(Constants.EventConstants.EVENT_SYSTEM_MINIMIZESTART, Constants.EventConstants.EVENT_SYSTEM_MINIMIZESTART, Hooks.RunningDLLInstance, minimize, 0, 0, (uint)(Constants.Contexts.WINEVENT_INCONTEXT| Constants.Contexts.WINEVENT_SKIPOWNPROCESS));
            hMinimizeEnd = WinAPIs.SetWinEventHook(Constants.EventConstants.EVENT_SYSTEM_MINIMIZEEND, Constants.EventConstants.EVENT_SYSTEM_MINIMIZEEND, Hooks.RunningDLLInstance, minimizeEnd, 0, 0, (uint)(Constants.Contexts.WINEVENT_INCONTEXT| Constants.Contexts.WINEVENT_SKIPOWNPROCESS));
            hMoveSize = WinAPIs.SetWinEventHook(Constants.EventConstants.EVENT_SYSTEM_MOVESIZESTART, Constants.EventConstants.EVENT_SYSTEM_MOVESIZESTART, Hooks.RunningDLLInstance, move, 0, 0, (uint)(Constants.Contexts.WINEVENT_INCONTEXT| Constants.Contexts.WINEVENT_SKIPOWNPROCESS));
            hMoveSizeEnd = WinAPIs.SetWinEventHook(Constants.EventConstants.EVENT_SYSTEM_MOVESIZEEND, Constants.EventConstants.EVENT_SYSTEM_MOVESIZEEND, Hooks.RunningDLLInstance, moveEnd, 0, 0, (uint)(Constants.Contexts.WINEVENT_INCONTEXT| Constants.Contexts.WINEVENT_SKIPOWNPROCESS));

        }


        public static void WinObjectCreateEventProc(IntPtr hWinEventHook, uint eventType,IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
           // Console.WriteLine("WinObjectCreateEventProc Invoked");


        }

        public static void WinObjectDestroyEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
           // Console.WriteLine("WinObjectDestroyEventProc Invoked");


        }

        public static void WinObjectShowEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            //Console.WriteLine("WinObjectShowEventProc Invoked");


        }

        public static void WinObjectSelectionEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {

            Console.WriteLine("WinObjectSelectionEventProc Invoked");

        }

        public static void WinMinimizeEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            Console.WriteLine("WinMinimizeEventProc Invoked");


        }

        public static void WinMinimizeEndEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {

            Console.WriteLine("WinMinimizeEndEventProc Invoked");

        }

        public static void WinMoveSizeEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            Console.WriteLine("WinMoveSizeEventProc Invoked");


        }

        public static void WinMoveSizeEndEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {

            Console.WriteLine("WinMoveSizeEndEventProc Invoked");

        }


        public static void UnInstallWindowEventHooks()
        {
            UnInstallResults.Add("create", WinAPIs.UnhookWinEvent(hCreate));
            UnInstallResults.Add("destroy", WinAPIs.UnhookWinEvent(hDestroy));
            UnInstallResults.Add("show", WinAPIs.UnhookWinEvent(hShow));
            UnInstallResults.Add("select", WinAPIs.UnhookWinEvent(hSelect));
            UnInstallResults.Add("minimize", WinAPIs.UnhookWinEvent(hMinimize));
            UnInstallResults.Add("minimizeEnd", WinAPIs.UnhookWinEvent(hMinimizeEnd));
            UnInstallResults.Add("move", WinAPIs.UnhookWinEvent(hMoveSize));
            UnInstallResults.Add("moveEnd", WinAPIs.UnhookWinEvent(hMoveSizeEnd));


        }

    }
}
