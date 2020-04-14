using Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
namespace FindApplicationUIElementsDesktopApp
{
    static class Program
    {
        static Queue<ScreenBoundingRectangle> shownRectangles = new Queue<ScreenBoundingRectangle>();
        static readonly object _object = new object();

        //public static Client c = new Client();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Application Started");
            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            /*Installing Hooks*/
            Hooks.UnInstallHooks();
            Hooks.InstallHooks();

            /*Installing WindowEventHooks*/
            WindowEventHooks.UnInstallWindowEventHooks();
            WindowEventHooks.InstallWindowsEventHooks();

            Hooks.OnMouseActivity += new MouseEventHandler(OnMouseLeftClick);
           // Hooks.OnMouseMovement += new MouseEventHandler(OnMouseMovement);

            WinAPIs.InitUiTreeWalk();
            //c.StartClient();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void OnApplicationExit(object sender, EventArgs e)
        {
            //c.ShutDownClient();
            WinAPIs.UnInitUiTreeWalk();
            Hooks.UnInstallHooks();
            //Hooks.UnInstallHooks();
            //foreach (var kp in Hooks.UnInstallResults)
            //{
            //    Console.WriteLine("Procedure is : " + kp.Key + " result is : " + kp.Value);
            //}

            WindowEventHooks.UnInstallWindowEventHooks();
            foreach (var kp in Hooks.UnInstallResults)
            {
                Console.WriteLine("Procedure is : " + kp.Key + " result is : " + kp.Value);
            }
        }


        public static void OnMouseLeftClick(object sender, MouseEventArgs m)
        {


            #region XPath
            string labelText = string.Empty;

            Form1.textBox.Text = "Resolving Xpath";
            Stopwatch s1 = new Stopwatch();
            s1.Start();
            Task resolveData = Task.Factory.StartNew(() =>
            {


                System.Windows.Point point = new System.Windows.Point(m.X, m.Y);
                AutomationElement el = AutomationElement.FromPoint(point);

                var processExecutablePath = WinAPIs.GetMainModuleFilepath(el.Current.ProcessId);
                var processName = Process.GetProcessById(el.Current.ProcessId).ProcessName;
                WinAPIs w = new WinAPIs();
                UIELementActivity u = new UIELementActivity();
                var hWindow = WinAPIs.WindowFromPoint(m.Location);
                string clickedWindow = "Clicked window is : " + w.GetWindowText(hWindow);

                Console.WriteLine(clickedWindow);
                string rawXPath = string.Empty;
                string preparedXml = string.Empty;

                #region uncomment to get from c++ library
                //Stopwatch s = new Stopwatch();
                //s.Start();
                //rawXPath = w.GetUiXPath(m.X, m.Y);
                //s.Stop();
                //Console.WriteLine("Elapsed Time is :" + s.ElapsedMilliseconds);
                //preparedXml = GenerateXPath.GetUITaskList(rawXPath);
                ////var xPath = GenerateXPath.GenerateXPathToUiElement(preparedXml);

                //labelText = clickedWindow + Environment.NewLine + String.Format("RawXPath is ={0}" + Environment.NewLine, preparedXml);
                #endregion

                #region own written code
                preparedXml = GenerateXPath.GetUITaskList(el);
                TrackedAction t1 = new TrackedAction
                {
                    CreatedAt = DateTime.Now,
                    IdentificationDetail = preparedXml,
                    ApplicationPath = processExecutablePath,
                    ProcessName = processName
                };
                new CRUD().Add(t1);
                #endregion
                Console.WriteLine("RawXPath is : " + preparedXml);
            });
            resolveData.Wait();

            //Task t = Task.Run(() => Program.c.SendMessage((m.X + "|" + m.Y)));
            Form1.textBox.Text = labelText + Environment.NewLine + "Elapsed time in Resolving data is  message is :" + s1.ElapsedMilliseconds;
            #endregion
        }


        public static void OnMouseMovement(object sender, MouseEventArgs m)
        {


            Task resolveData = Task.Factory.StartNew(() =>
            {


                System.Windows.Point point = new System.Windows.Point(m.X, m.Y);
                AutomationElement el = AutomationElement.FromPoint(point);
                SetVisibility(true, el);

            });
            resolveData.Wait();

        }



        public static void SetVisibility(bool show, AutomationElement element)
        {
            lock (_object)
            {


                if (shownRectangles.Count > 0)
                    shownRectangles.Dequeue().Dispose();
                ScreenBoundingRectangle _rectangle = new ScreenBoundingRectangle();
                _rectangle.Color = Color.Red;
                _rectangle.Opacity = 0.8;
                _rectangle.Location = new Rectangle(Convert.ToInt32(element.Current.BoundingRectangle.X), Convert.ToInt32(element.Current.BoundingRectangle.Y), Convert.ToInt32(element.Current.BoundingRectangle.Width), Convert.ToInt32(element.Current.BoundingRectangle.Height));
                _rectangle.ToolTipText = "hello";
                _rectangle.Visible = show;
                shownRectangles.Enqueue(_rectangle);
            }
        }

    }
}
