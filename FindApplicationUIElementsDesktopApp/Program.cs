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
        public static Queue<System.Windows.Point> toBeActed = new Queue<System.Windows.Point>();

        public static Queue<ScreenBoundingRectangle> shownRectangles = new Queue<ScreenBoundingRectangle>();
        public static System.Windows.Rect prev = new System.Windows.Rect();
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
            Task movemnetTask = Task.Factory.StartNew(() =>
            {


                Hooks.OnMouseMovement += new MouseEventHandler(OnMouseMovement);
            });

            Task startProcessingMovedPoint = Task.Factory.StartNew(() =>
            {
                ProcessMovedEvents();
            });

            Hooks.OnMouseActivity += new MouseEventHandler(OnMouseLeftClick);
            //WinAPIs.InitUiTreeWalk();
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
                //Console.WriteLine("RawXPath is : " + preparedXml);
            });
            resolveData.Wait();

            //Task t = Task.Run(() => Program.c.SendMessage((m.X + "|" + m.Y)));
            Form1.textBox.Text = labelText + Environment.NewLine + "Elapsed time in Resolving data is  message is :" + s1.ElapsedMilliseconds;
            #endregion
        }


        public static void OnMouseMovement(object sender, MouseEventArgs m)
        {


            System.Windows.Point point = new System.Windows.Point(m.X, m.Y);
            //if (IsPointInsideRectangle(prev, point))
            //    return;
            //else
                toBeActed.Enqueue(point);
            #region earlier code to highlight
            //TreeWalker t = TreeWalker.RawViewWalker;

            //    try
            //    {
            //        AutomationElement el = AutomationElement.FromPoint(point);
            //        var setPrevEleTask = Task.Factory.StartNew(() =>
            //        {
            //            if (el.FindFirst(TreeScope.Children, Condition.TrueCondition) == null)
            //            {
            //                try
            //                {
            //                    object boundingRectNoDefault = el.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty, true);
            //                    if (boundingRectNoDefault != AutomationElement.NotSupported)
            //                    {
            //                        prev = (System.Windows.Rect)boundingRectNoDefault;
            //                    }
            //                }
            //                catch (Exception)
            //                {

            //                }

            //            }
            //        });

            //        new Utility().SetVisibility(true, el);

            //        setPrevEleTask.Wait();
            //    }
            //    catch (Exception)
            //    {

            //    }

            #endregion




            //});
            //resolveData.Wait();

        }
        public static bool IsPointInsideRectangle(System.Windows.Rect r, System.Windows.Point p)
        {


            if (r.Contains(p))
                return true;
            else
                return false;

        }


        public static void ProcessMovedEvents()
        {
            while (true)
            {
                try
                {
                    if (toBeActed.Count > 0)
                    {
                        var p = toBeActed.Dequeue();
                        TreeWalker t = TreeWalker.RawViewWalker;

                        try
                        {
                            AutomationElement el = AutomationElement.FromPoint(p);
                            //Console.WriteLine("X=  " + p.X + "   Y =   " + p.Y + "       " + el.Current.ClassName + "               " + el.Current.ControlType.ProgrammaticName);
                            var setPrevEleTask = Task.Factory.StartNew(() =>
                            {
                                if (el.FindFirst(TreeScope.Children, Condition.TrueCondition) == null)
                                {
                                    try
                                    {
                                        object boundingRectNoDefault = el.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty, true);
                                        if (boundingRectNoDefault != AutomationElement.NotSupported)
                                        {
                                            prev = (System.Windows.Rect)boundingRectNoDefault;
                                        }
                                    }
                                    catch (Exception)
                                    {

                                    }

                                }
                            });

                            new Utility().SetVisibility(true, el);

                            setPrevEleTask.Wait();
                        }
                        catch (Exception)
                        {

                        }
                        toBeActed.Clear();

                    }
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
        }



    }
}
