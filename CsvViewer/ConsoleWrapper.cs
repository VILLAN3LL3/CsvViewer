using System;

namespace CsvViewer
{
    public class ConsoleWrapper : IConsole
    {
        public void Write(string message) => Console.Write(message);

        public void WriteLine(string message) => Console.WriteLine(message);

        public string ReadLine() => Console.ReadLine();

        public ConsoleKeyInfo ReadKey() => Console.ReadKey();
    }
}
