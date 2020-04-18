using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace FindApplicationUIElementsDesktopApp
{
    public class Utility
    {
        public void SetVisibility(bool show, AutomationElement element)
        {

            try
            {

                if (Program.shownRectangles.Count > 0)
                    Program.shownRectangles.Dequeue().Dispose();
                ScreenBoundingRectangle _rectangle = new ScreenBoundingRectangle();
                _rectangle.Color = Color.Red;
                _rectangle.Opacity = 0.8;
                _rectangle.Location = new Rectangle(Convert.ToInt32(element.Current.BoundingRectangle.X), Convert.ToInt32(element.Current.BoundingRectangle.Y), Convert.ToInt32(element.Current.BoundingRectangle.Width), Convert.ToInt32(element.Current.BoundingRectangle.Height));
                _rectangle.ToolTipText = "hello";
                _rectangle.Visible = show;
                Program.shownRectangles.Enqueue(_rectangle);
            }
            catch (Exception)
            {

            }
        }

    }
}
