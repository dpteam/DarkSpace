using System.Diagnostics;

namespace DarkSpace
{
    internal class Program
    {
        static void Main()
        {
            var ServerPort = 20042;
            Trace.AutoFlush = true;
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(new TextWriterTraceListener(System.IO.Path.GetFileNameWithoutExtension(typeof(Program).Assembly.GetName().Name) + "-server.log"));
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.PriorityClass = ProcessPriorityClass.High;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Trace.WriteLine($"Server started at port {ServerPort}");
        }
    }
}