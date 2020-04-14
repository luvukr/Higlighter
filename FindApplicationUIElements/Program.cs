using HooksLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindApplicationUIElements
{
    public class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 r go to Debug > Start Without Debugging) to run your app.
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            Thread t = new Thread(Hooks.InstallHooks);
            t.Start();
            //Hooks.InstallHooks();
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Hooks.UnInstallHooks();
            foreach(var kp in Hooks.UnInstallResults)
            {
                Console.WriteLine("Procedure is : " + kp.Key + " result is : " + kp.Value);
            }
            Console.WriteLine("Shutting down...");
            // Cleanup here
            System.Threading.Thread.Sleep(750);
        }

    }
}
