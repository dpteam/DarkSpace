using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Media.Animation;
using DarkSpace.Config;

namespace DarkSpace
{
    internal class ProgramClient
    {
        public static void ClientRun()
        {
            System.Runtime.InteropServices.Marshal.PrelinkAll(typeof(Program));

            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.PriorityClass = ProcessPriorityClass.High;

            string cfgKernelVersionStage = "__0lpha__";
            string cfgKernelVersion = "1.0.2";
            string cfgSaveMetaVersion = "0.0.1";
            string cfgSaveDataPlayable = "0";

            Console.BackgroundColor = ConsoleColor.Black;

            //PrintStringFatalError("Kernel Panic");
            //PrintStringFatalError("0xFFFFFFFF: No CRC[Code-Reproduction-Code]");

            Trace.AutoFlush = true;
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(new TextWriterTraceListener(System.IO.Path.GetFileNameWithoutExtension(typeof(Program).Assembly.GetName().Name) + ".log"));

            if (ConfigManager.__KERNEL_DEBUG_MODE == true)
            {
                Print("[INFO]" + Local.strDbgModeOn);
            }

            string IniFileName = System.IO.Path.GetFileNameWithoutExtension(typeof(Program).Assembly.GetName().Name) + ".ini";

            IniFile INI = new IniFile(IniFileName);
            if (System.IO.File.Exists(IniFileName))
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Trace.WriteLine("[DEBUG] Конфигурционный файл найден");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Trace.WriteLine("[ERROR] Конфигурционный файл не найден, идет создание...");
                INI.Write("Kernel", "VersionStage", cfgKernelVersionStage);
                INI.Write("Kernel", "Version", cfgKernelVersion);
                INI.Write("SaveMeta", "Version", cfgSaveMetaVersion);
                INI.Write("SaveData", "Playable", cfgSaveDataPlayable);
                Console.ReadKey();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Trace.WriteLine("____________________________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.Red;
            Trace.WriteLine("   /$$$$$$$                      /$$        /$$$$$$                                         ");
            Trace.WriteLine("  | $$__  $$                    | $$       /$$__  $$                                        ");
            Trace.WriteLine("  | $$  \\ $$  /$$$$$$   /$$$$$$ | $$   /$$| $$  \\__/  /$$$$$$   /$$$$$$   /$$$$$$$  /$$$$$$ ");
            Trace.WriteLine("  | $$  | $$ |____  $$ /$$__  $$| $$  /$$/|  $$$$$$  /$$__  $$ |____  $$ /$$_____/ /$$__  $$");
            Trace.WriteLine("  | $$  | $$  /$$$$$$$| $$  \\__/| $$$$$$/  \\____  $$| $$  \\ $$  /$$$$$$$| $$      | $$$$$$$$");
            Trace.WriteLine("  | $$  | $$ /$$__  $$| $$      | $$_  $$  /$$  \\ $$| $$  | $$ /$$__  $$| $$      | $$_____/");
            Trace.WriteLine("  | $$$$$$$/|  $$$$$$$| $$      | $$ \\  $$|  $$$$$$/| $$$$$$$/|  $$$$$$$|  $$$$$$$|  $$$$$$$");
            Trace.WriteLine("  |_______/  \\_______/|__/      |__/  \\__/ \\______/ | $$____/  \\_______/ \\_______/ \\_______/");
            Trace.WriteLine("                                                    | $$                                    ");
            Trace.WriteLine("                                                    | $$                                    ");
            Trace.WriteLine("                                                    |__/                                    ");
            Console.ForegroundColor = ConsoleColor.White;
            Trace.WriteLine("____________________________________________________________________________________________");

            // Seperator
            Trace.WriteLine("");

            // Welcome
            Trace.WriteLine(Local.strWelcome);

            // Seperator
            Trace.WriteLine("");

            // Selector
            int menuSelectorNum;
            Trace.WriteLine(Local.strSelector);
            Trace.WriteLine(Local.strSelectorNewGame);
            Trace.WriteLine(Local.strSelectorLoadGame);
            Trace.WriteLine(Local.strSelectorExit);
            menuSelectorNum = Convert.ToInt32(Console.ReadLine());

            if (menuSelectorNum == 1)
            {
                Console.Clear();
                try
                {
                    //Trace.WriteLine("Вы начали новую игру");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                catch(Exception ex)
                {
                    PrintStringFatalError(ex.ToString());
                    Environment.Exit(0);
                }
            }
            if (menuSelectorNum == 2)
            {
                if (cfgKernelVersionStage == INI.ReadINI("Kernel", "VersionStage"))
                if (cfgKernelVersion == INI.ReadINI("Kernel", "Version"))
                if (cfgSaveMetaVersion == INI.ReadINI("SaveMeta", "Version"))
                if (cfgSaveDataPlayable != INI.ReadINI("SaveData", "Playable"))
                {
                    try
                    {
                        Console.Clear();
                        
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    catch
                    {
                        PrintStringFatalError(Local.strLoadGameFailed);
                        Environment.Exit(0);
                    }
                }
                else
                {

                }
            }
            if (menuSelectorNum == 3)
            {
                Environment.Exit(0);
                //System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            else
            {
                PrintStringFatalError(Local.strUnknownFatalError);
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void Print(string __string)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Trace.WriteLine(__string);
        }

        public static void PrintStringFatalError(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Trace.WriteLine("[FATAL] " + str);
            Console.ReadKey();
            Environment.Exit(0);
        }

    }
}
