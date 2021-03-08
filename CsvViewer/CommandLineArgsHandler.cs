using System;
using CsvViewer.Model;

namespace CsvViewer
{
    public class CommandLineArgsHandler
    {
        private readonly IConsole _console;

        public CommandLineArgsHandler(IConsole console)
        {
            _console = console;
        }

        public CommandLineArg GetCommandLineArgs(string[] args) => new CommandLineArg(GetPath(args), GetPageSize(args));

        private string GetPath(string[] args)
        {
            if (args is null || args.Length == 0)
            {
                _console.WriteLine("Please enter the path to the csv file you want to display");
                return _console.ReadLine();
            }
            else
            {
                return args[0];
            }
        }

        private int GetPageSize(string[] args)
        {
            string pageSizeString;
            if (args is null || args.Length < 2)
            {
                _console.WriteLine("Please enter the page size");
                pageSizeString = _console.ReadLine();
            }
            else
            {
                pageSizeString = args[1];
            }

            return !int.TryParse(pageSizeString, out int pageSize)
                ? throw new ArgumentOutOfRangeException(nameof(pageSizeString), $"'{pageSizeString}' is not a valid value for the page size")
                : pageSize;
        }
    }
}
