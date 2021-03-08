using System;

namespace CsvViewer
{
    public interface IConsole
    {
        void Write(string message);
        void WriteLine(string message);
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}
