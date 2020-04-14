using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;

namespace FindApplicationUIElementsDesktopApp
{
    public class UIELementActivity
    {
        public static TreeWalker walker = TreeWalker.RawViewWalker;


        public AutomationElement GetAutomationElement(int x,int y)
        {
            System.Windows.Point point = new System.Windows.Point(x, y);
            AutomationElement el = AutomationElement.FromPoint(point);
            return el;
        }

        public AutomationElement GetAutomationElement(IntPtr p)
        {
            AutomationElement el = AutomationElement.FromHandle(p);
            return el;
        }

        public AutomationElement GetRootAutomationElement()
        {
            AutomationElement el = AutomationElement.RootElement;
            return el;
        }


    }
}
