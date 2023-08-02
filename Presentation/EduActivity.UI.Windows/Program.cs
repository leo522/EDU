using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using AppFramework.Windows.Forms.CommandLine;

namespace KMU.EduActivity.UI.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //ICommandLineParser parser = new CommandLineParser();
            //if (parser.ParseArguments(args, CommandLineArgs.Current))
            //{                
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}