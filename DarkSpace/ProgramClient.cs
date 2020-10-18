using System;

namespace DarkSpace
{
    internal class ProgramClient
    {
        public static void ClientRun()
        {
            System.Runtime.InteropServices.Marshal.PrelinkAll(typeof(Program));
            Console.BackgroundColor = ConsoleColor.Black;

            /*
            string[] gangNames = { "Alpha", "Beta", "Omega" };

            foreach (string gangNameElement in gangNames) {
                Console.WriteLine("Gang: " + gangNameElement);
            }
            */

            //PrintStringFatalError("Kernel Panic");
            //PrintStringFatalError("0xFFFFFFFF: No CRC[Code-Reproduction-Code]");

            bool __KERNEL_DEBUG_MODE = true;
            if (__KERNEL_DEBUG_MODE == true)
            {
                //sp2.Speak(Local.strDbgModeOn, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                Print("[INFO]" + Local.strDbgModeOn);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("____________________________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   /$$$$$$$                      /$$        /$$$$$$                                         ");
            Console.WriteLine("  | $$__  $$                    | $$       /$$__  $$                                        ");
            Console.WriteLine("  | $$  \\ $$  /$$$$$$   /$$$$$$ | $$   /$$| $$  \\__/  /$$$$$$   /$$$$$$   /$$$$$$$  /$$$$$$ ");
            Console.WriteLine("  | $$  | $$ |____  $$ /$$__  $$| $$  /$$/|  $$$$$$  /$$__  $$ |____  $$ /$$_____/ /$$__  $$");
            Console.WriteLine("  | $$  | $$  /$$$$$$$| $$  \\__/| $$$$$$/  \\____  $$| $$  \\ $$  /$$$$$$$| $$      | $$$$$$$$");
            Console.WriteLine("  | $$  | $$ /$$__  $$| $$      | $$_  $$  /$$  \\ $$| $$  | $$ /$$__  $$| $$      | $$_____/");
            Console.WriteLine("  | $$$$$$$/|  $$$$$$$| $$      | $$ \\  $$|  $$$$$$/| $$$$$$$/|  $$$$$$$|  $$$$$$$|  $$$$$$$");
            Console.WriteLine("  |_______/  \\_______/|__/      |__/  \\__/ \\______/ | $$____/  \\_______/ \\_______/ \\_______/");
            Console.WriteLine("                                                    | $$                                    ");
            Console.WriteLine("                                                    | $$                                    ");
            Console.WriteLine("                                                    |__/                                    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("____________________________________________________________________________________________");

            // Seperator
            Console.WriteLine("");

            // Welcome
            Console.WriteLine(Local.strWelcome);

            // Seperator
            Console.WriteLine("");

            // Selector
            int menuSelectorNum;
            Console.WriteLine(Local.strSelector);
            Console.WriteLine(Local.strSelectorNewGame);
            Console.WriteLine(Local.strSelectorExit);
            menuSelectorNum = Convert.ToInt32(Console.ReadLine());

            if (menuSelectorNum == 1)
            {
                Console.Clear();
                Console.WriteLine("Вы начали новую игру");
            }
            if (menuSelectorNum == 2)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            else
            {
                PrintStringFatalError(Local.strUnknownFatalError);
            }

            Console.ReadKey();
        }

        public static void Print(string __string)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(__string);
        }

        public static void PrintStringFatalError(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[FATAL] " + str);
        }

    }
}
