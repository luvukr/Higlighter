using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FindApplicationUIElementsDesktopApp
{

    public class Constants
    {
        public class WindowsHookConstans
        {
            public const int WH_KEYBOARD = 2;
            public const int WH_GETMESSAGE = 3;
            public const int WH_CALLWNDPROC = 4;
            //public const int WH_CBT = 5;
            public const int WH_MOUSE = 7;
            //public const int WH_DEBUG = 9;
            //public const int WH_CALLWNDPROCRET = 12;
            public const int WH_KEYBOARD_LL = 13;
            public const int WH_MOUSE_LL = 14;

        }

        //
        // Summary:
        //     Specifies constants that define which mouse button was pressed.
        [ComVisible(true)]
        [Flags]
        public enum MouseButtons
        {
            //
            // Summary:
            //     No mouse button was pressed.
            None = 0,
            //
            // Summary:
            //     The left mouse button was pressed.
            Left = 1048576,
            //
            // Summary:
            //     The right mouse button was pressed.
            Right = 2097152,
            //
            // Summary:
            //     The middle mouse button was pressed.
            Middle = 4194304,
            //
            // Summary:
            //     The first XButton was pressed.
            XButton1 = 8388608,
            //
            // Summary:
            //     The second XButton was pressed.
            XButton2 = 16777216
        }


        public class MouseEvents
        {
            public const int WM_MOUSEFIRST = 0x0200;
            public const int WM_MOUSEMOVE = 0x0200;
            public const int WM_LBUTTONDOWN = 0x0201;
            public const int WM_LBUTTONUP = 0x0202;
            public const int WM_LBUTTONDBLCLK = 0x0203;
            public const int WM_RBUTTONDOWN = 0x0204;
            public const int WM_RBUTTONUP = 0x0205;
            public const int WM_RBUTTONDBLCLK = 0x0206;
            public const int WM_MBUTTONDOWN = 0x0207;
            public const int WM_MBUTTONUP = 0x0208;
            public const int WM_MBUTTONDBLCLK = 0x0209;
            public const int WM_MOUSEWHEEL = 0x020A;
            public const int WM_XBUTTONDOWN = 0x020B;
            public const int WM_XBUTTONUP = 0x020C;
            public const int WM_XBUTTONDBLCLK = 0x020D;
        }

        public class EventConstants
        {
            public const uint WINEVENT_OUTOFCONTEXT = 0x0000; // Events are ASYNC
            public const uint WINEVENT_SKIPOWNTHREAD = 0x0001; // Don't call back for events on installer's thread
            public const uint WINEVENT_SKIPOWNPROCESS = 0x0002; // Don't call back for events on installer's process
            public const uint WINEVENT_INCONTEXT = 0x0004; // Events are SYNC, this causes your dll to be injected into every process
            public const uint EVENT_MIN = 0x00000001;
            public const uint EVENT_MAX = 0x7FFFFFFF;
            public const uint EVENT_SYSTEM_SOUND = 0x0001;
            public const uint EVENT_SYSTEM_ALERT = 0x0002;
            public const uint EVENT_SYSTEM_FOREGROUND = 0x0003;
            public const uint EVENT_SYSTEM_MENUSTART = 0x0004;
            public const uint EVENT_SYSTEM_MENUEND = 0x0005;
            public const uint EVENT_SYSTEM_MENUPOPUPSTART = 0x0006;
            public const uint EVENT_SYSTEM_MENUPOPUPEND = 0x0007;
            public const uint EVENT_SYSTEM_CAPTURESTART = 0x0008;
            public const uint EVENT_SYSTEM_CAPTUREEND = 0x0009;
            public const uint EVENT_SYSTEM_MOVESIZESTART = 0x000A;
            public const uint EVENT_SYSTEM_MOVESIZEEND = 0x000B;
            public const uint EVENT_SYSTEM_CONTEXTHELPSTART = 0x000C;
            public const uint EVENT_SYSTEM_CONTEXTHELPEND = 0x000D;
            public const uint EVENT_SYSTEM_DRAGDROPSTART = 0x000E;
            public const uint EVENT_SYSTEM_DRAGDROPEND = 0x000F;
            public const uint EVENT_SYSTEM_DIALOGSTART = 0x0010;
            public const uint EVENT_SYSTEM_DIALOGEND = 0x0011;
            public const uint EVENT_SYSTEM_SCROLLINGSTART = 0x0012;
            public const uint EVENT_SYSTEM_SCROLLINGEND = 0x0013;
            public const uint EVENT_SYSTEM_SWITCHSTART = 0x0014;
            public const uint EVENT_SYSTEM_SWITCHEND = 0x0015;
            public const uint EVENT_SYSTEM_MINIMIZESTART = 0x0016;
            public const uint EVENT_SYSTEM_MINIMIZEEND = 0x0017;
            public const uint EVENT_SYSTEM_DESKTOPSWITCH = 0x0020;
            public const uint EVENT_SYSTEM_END = 0x00FF;
            public const uint EVENT_OEM_DEFINED_START = 0x0101;
            public const uint EVENT_OEM_DEFINED_END = 0x01FF;
            public const uint EVENT_UIA_EVENTID_START = 0x4E00;
            public const uint EVENT_UIA_EVENTID_END = 0x4EFF;
            public const uint EVENT_UIA_PROPID_START = 0x7500;
            public const uint EVENT_UIA_PROPID_END = 0x75FF;
            public const uint EVENT_CONSOLE_CARET = 0x4001;
            public const uint EVENT_CONSOLE_UPDATE_REGION = 0x4002;
            public const uint EVENT_CONSOLE_UPDATE_SIMPLE = 0x4003;
            public const uint EVENT_CONSOLE_UPDATE_SCROLL = 0x4004;
            public const uint EVENT_CONSOLE_LAYOUT = 0x4005;
            public const uint EVENT_CONSOLE_START_APPLICATION = 0x4006;
            public const uint EVENT_CONSOLE_END_APPLICATION = 0x4007;
            public const uint EVENT_CONSOLE_END = 0x40FF;
            public const uint EVENT_OBJECT_CREATE = 0x8000; // hwnd ID idChild is created item
            public const uint EVENT_OBJECT_DESTROY = 0x8001; // hwnd ID idChild is destroyed item
            public const uint EVENT_OBJECT_SHOW = 0x8002; // hwnd ID idChild is shown item
            public const uint EVENT_OBJECT_HIDE = 0x8003; // hwnd ID idChild is hidden item
            public const uint EVENT_OBJECT_REORDER = 0x8004; // hwnd ID idChild is parent of zordering children
            public const uint EVENT_OBJECT_FOCUS = 0x8005; // hwnd ID idChild is focused item
            public const uint EVENT_OBJECT_SELECTION = 0x8006; // hwnd ID idChild is selected item (if only one); or idChild is OBJID_WINDOW if complex
            public const uint EVENT_OBJECT_SELECTIONADD = 0x8007; // hwnd ID idChild is item added
            public const uint EVENT_OBJECT_SELECTIONREMOVE = 0x8008; // hwnd ID idChild is item removed
            public const uint EVENT_OBJECT_SELECTIONWITHIN = 0x8009; // hwnd ID idChild is parent of changed selected items
            public const uint EVENT_OBJECT_STATECHANGE = 0x800A; // hwnd ID idChild is item w/ state change
            public const uint EVENT_OBJECT_LOCATIONCHANGE = 0x800B; // hwnd ID idChild is moved/sized item
            public const uint EVENT_OBJECT_NAMECHANGE = 0x800C; // hwnd ID idChild is item w/ name change
            public const uint EVENT_OBJECT_DESCRIPTIONCHANGE = 0x800D; // hwnd ID idChild is item w/ desc change
            public const uint EVENT_OBJECT_VALUECHANGE = 0x800E; // hwnd ID idChild is item w/ value change
            public const uint EVENT_OBJECT_PARENTCHANGE = 0x800F; // hwnd ID idChild is item w/ new parent
            public const uint EVENT_OBJECT_HELPCHANGE = 0x8010; // hwnd ID idChild is item w/ help change
            public const uint EVENT_OBJECT_DEFACTIONCHANGE = 0x8011; // hwnd ID idChild is item w/ def action change
            public const uint EVENT_OBJECT_ACCELERATORCHANGE = 0x8012; // hwnd ID idChild is item w/ keybd accel change
            public const uint EVENT_OBJECT_INVOKED = 0x8013; // hwnd ID idChild is item invoked
            public const uint EVENT_OBJECT_TEXTSELECTIONCHANGED = 0x8014; // hwnd ID idChild is item w? test selection change
            public const uint EVENT_OBJECT_CONTENTSCROLLED = 0x8015;
            public const uint EVENT_SYSTEM_ARRANGMENTPREVIEW = 0x8016;
            public const uint EVENT_OBJECT_END = 0x80FF;
            public const uint EVENT_AIA_START = 0xA000;
            public const uint EVENT_AIA_END = 0xAFFF;
        }

        public enum Contexts
        {
            WINEVENT_INCONTEXT,
            WINEVENT_OUTOFCONTEXT ,
            WINEVENT_SKIPOWNPROCESS,
            WINEVENT_SKIPOWNTHREAD
        }


        public enum VirtualKeys : int
        {
            VK_LBUTTON = 0x01,
            VK_RBUTTON = 0x02,
            VK_CANCEL = 0x03,
            VK_MBUTTON = 0x04,
            //
            VK_XBUTTON1 = 0x05,
            VK_XBUTTON2 = 0x06,
            //
            VK_BACK = 0x08,
            VK_TAB = 0x09,
            //
            VK_CLEAR = 0x0C,
            VK_RETURN = 0x0D,
            //
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11,
            VK_MENU = 0x12,
            VK_PAUSE = 0x13,
            VK_CAPITAL = 0x14,
            //
            VK_KANA = 0x15,
            VK_HANGEUL = 0x15,  /* old name - should be here for compatibility */
            VK_HANGUL = 0x15,
            VK_JUNJA = 0x17,
            VK_FINAL = 0x18,
            VK_HANJA = 0x19,
            VK_KANJI = 0x19,
            //
            VK_ESCAPE = 0x1B,
            //
            VK_CONVERT = 0x1C,
            VK_NONCONVERT = 0x1D,
            VK_ACCEPT = 0x1E,
            VK_MODECHANGE = 0x1F,
            //
            VK_SPACE = 0x20,
            VK_PRIOR = 0x21,
            VK_NEXT = 0x22,
            VK_END = 0x23,
            VK_HOME = 0x24,
            VK_LEFT = 0x25,
            VK_UP = 0x26,
            VK_RIGHT = 0x27,
            VK_DOWN = 0x28,
            VK_SELECT = 0x29,
            VK_PRINT = 0x2A,
            VK_EXECUTE = 0x2B,
            VK_SNAPSHOT = 0x2C,
            VK_INSERT = 0x2D,
            VK_DELETE = 0x2E,
            VK_HELP = 0x2F,

            A = 0x41,
            B = 0x42,
            C = 0x43,
            D = 0x44,
            E = 0x45,
            F = 0x46,
            G = 0x47,
            H = 0x48,
            I = 0x49,
            J = 0x4A,
            K = 0x4B,
            L = 0x4C,
            M = 0x4D,
            N = 0x4E,
            O = 0x4F,
            P = 0x50,
            Q = 0x51,
            R = 0x52,
            S = 0x53,
            T = 0x54,
            U = 0x55,
            V = 0x56,
            W = 0x57,
            X = 0x58,
            Y = 0x59,
            Z = 0x5A,

            //
            VK_LWIN = 0x5B,
            VK_RWIN = 0x5C,
            VK_APPS = 0x5D,
            //
            VK_SLEEP = 0x5F,
            //
            VK_NUMPAD0 = 0x60,
            VK_NUMPAD1 = 0x61,
            VK_NUMPAD2 = 0x62,
            VK_NUMPAD3 = 0x63,
            VK_NUMPAD4 = 0x64,
            VK_NUMPAD5 = 0x65,
            VK_NUMPAD6 = 0x66,
            VK_NUMPAD7 = 0x67,
            VK_NUMPAD8 = 0x68,
            VK_NUMPAD9 = 0x69,
            VK_MULTIPLY = 0x6A,
            VK_ADD = 0x6B,
            VK_SEPARATOR = 0x6C,
            VK_SUBTRACT = 0x6D,
            VK_DECIMAL = 0x6E,
            VK_DIVIDE = 0x6F,
            VK_F1 = 0x70,
            VK_F2 = 0x71,
            VK_F3 = 0x72,
            VK_F4 = 0x73,
            VK_F5 = 0x74,
            VK_F6 = 0x75,
            VK_F7 = 0x76,
            VK_F8 = 0x77,
            VK_F9 = 0x78,
            VK_F10 = 0x79,
            VK_F11 = 0x7A,
            VK_F12 = 0x7B,
            VK_F13 = 0x7C,
            VK_F14 = 0x7D,
            VK_F15 = 0x7E,
            VK_F16 = 0x7F,
            VK_F17 = 0x80,
            VK_F18 = 0x81,
            VK_F19 = 0x82,
            VK_F20 = 0x83,
            VK_F21 = 0x84,
            VK_F22 = 0x85,
            VK_F23 = 0x86,
            VK_F24 = 0x87,
            //
            VK_NUMLOCK = 0x90,
            VK_SCROLL = 0x91,
            //
            VK_OEM_NEC_EQUAL = 0x92,   // '=' key on numpad
                                       //
            VK_OEM_FJ_JISHO = 0x92,   // 'Dictionary' key
            VK_OEM_FJ_MASSHOU = 0x93,   // 'Unregister word' key
            VK_OEM_FJ_TOUROKU = 0x94,   // 'Register word' key
            VK_OEM_FJ_LOYA = 0x95,   // 'Left OYAYUBI' key
            VK_OEM_FJ_ROYA = 0x96,   // 'Right OYAYUBI' key
                                     //
            VK_LSHIFT = 0xA0,
            VK_RSHIFT = 0xA1,
            VK_LCONTROL = 0xA2,
            VK_RCONTROL = 0xA3,
            VK_LMENU = 0xA4,
            VK_RMENU = 0xA5,
            //
            VK_BROWSER_BACK = 0xA6,
            VK_BROWSER_FORWARD = 0xA7,
            VK_BROWSER_REFRESH = 0xA8,
            VK_BROWSER_STOP = 0xA9,
            VK_BROWSER_SEARCH = 0xAA,
            VK_BROWSER_FAVORITES = 0xAB,
            VK_BROWSER_HOME = 0xAC,
            //
            VK_VOLUME_MUTE = 0xAD,
            VK_VOLUME_DOWN = 0xAE,
            VK_VOLUME_UP = 0xAF,
            VK_MEDIA_NEXT_TRACK = 0xB0,
            VK_MEDIA_PREV_TRACK = 0xB1,
            VK_MEDIA_STOP = 0xB2,
            VK_MEDIA_PLAY_PAUSE = 0xB3,
            VK_LAUNCH_MAIL = 0xB4,
            VK_LAUNCH_MEDIA_SELECT = 0xB5,
            VK_LAUNCH_APP1 = 0xB6,
            VK_LAUNCH_APP2 = 0xB7,
            //
            VK_OEM_1 = 0xBA,   // ';:' for US
            VK_OEM_PLUS = 0xBB,   // '+' any country
            VK_OEM_COMMA = 0xBC,   // ',' any country
            VK_OEM_MINUS = 0xBD,   // '-' any country
            VK_OEM_PERIOD = 0xBE,   // '.' any country
            VK_OEM_2 = 0xBF,   // '/?' for US
            VK_OEM_3 = 0xC0,   // '`~' for US
                               //
            VK_OEM_4 = 0xDB,  //  '[{' for US
            VK_OEM_5 = 0xDC,  //  '\|' for US
            VK_OEM_6 = 0xDD,  //  ']}' for US
            VK_OEM_7 = 0xDE,  //  ''"' for US
            VK_OEM_8 = 0xDF,
            //
            VK_OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
            VK_OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
            VK_ICO_HELP = 0xE3,  //  Help key on ICO
            VK_ICO_00 = 0xE4,  //  00 key on ICO
                               //
            VK_PROCESSKEY = 0xE5,
            //
            VK_ICO_CLEAR = 0xE6,
            //
            VK_PACKET = 0xE7,
            //
            VK_OEM_RESET = 0xE9,
            VK_OEM_JUMP = 0xEA,
            VK_OEM_PA1 = 0xEB,
            VK_OEM_PA2 = 0xEC,
            VK_OEM_PA3 = 0xED,
            VK_OEM_WSCTRL = 0xEE,
            VK_OEM_CUSEL = 0xEF,
            VK_OEM_ATTN = 0xF0,
            VK_OEM_FINISH = 0xF1,
            VK_OEM_COPY = 0xF2,
            VK_OEM_AUTO = 0xF3,
            VK_OEM_ENLW = 0xF4,
            VK_OEM_BACKTAB = 0xF5,
            //
            VK_ATTN = 0xF6,
            VK_CRSEL = 0xF7,
            VK_EXSEL = 0xF8,
            VK_EREOF = 0xF9,
            VK_PLAY = 0xFA,
            VK_ZOOM = 0xFB,
            VK_NONAME = 0xFC,
            VK_PA1 = 0xFD,
            VK_OEM_CLEAR = 0xFE
        }


        public class AncestorFlags
        {

            public const uint GA_PARENT = 1; // Retrieves the parent window.This does not include the owner, as it does with the GetParent function.

            public const uint GA_ROOT = 2; // Retrieves the root window by walking the chain of parent windows.

            public const uint GA_ROOTOWNER = 3; // Retrieves the owned root window by walking the chain of parent and owner windows returned by GetParent.
        }
        public class NativeMethods
        {
            public const int DLGC_STATIC = 0x100;
            public const int GWL_EXSTYLE = -20;
            public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
            public const uint MOD_ALT = 1;
            public const uint MOD_CONTROL = 2;
            public const uint MOD_SHIFT = 4;
            public const uint OBJ_BITMAP = 7;
            public const int SRCCOPY = 0xcc0020;
            public const int SW_RESTORE = 9;
            public const int SW_SHOWNA = 8;
            public const int SWP_NOACTIVATE = 0x10;
            public const int TOKEN_ELEVATION = 20;
            public const int TOKEN_ELEVATION_TYPE = 0x12;
            public const int TOKEN_ELEVATION_TYPE_DEFAULT = 1;
            public const int TOKEN_ELEVATION_TYPE_FULL = 2;
            public const int TOKEN_ELEVATION_TYPE_LIMITED = 3;
            public const int TOKEN_QUERY = 8;
            public const int VK_F1 = 0x70;
            public const uint VK_R = 0x52;
            public const int VK_SHIFT = 0x10;
            public const int WM_GETDLGCODE = 0x87;
            public const int WM_HOTKEY = 0x312;
            public const int WM_KEYDOWN = 0x100;
            public const int WM_NCLBUTTONDBLCLK = 0xa3;
            public const int WS_EX_TOOLWINDOW = 0x80;
        }
    }
}

