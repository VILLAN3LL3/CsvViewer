using System;
using System.Collections.Generic;
using CsvViewer.Model;

namespace CsvViewer
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var console = new ConsoleWrapper();
            try
            {
                var commandLineArgsHandler = new CommandLineArgsHandler(console);
                CommandLineArg arguments = commandLineArgsHandler.GetCommandLineArgs(args);

                Console.WriteLine($"I will now display the first page of the csv table on path {arguments.Path} with a maximum page size of {arguments.PageSize}:");

                var interactor = new CsvInteractor(arguments);

                var commands = new Dictionary<ConsoleKey, Func<IList<string>>>()
                {
                    { ConsoleKey.N, () => interactor.GoToNextPage() },
                    { ConsoleKey.P, () => interactor.GoToPreviousPage() },
                    { ConsoleKey.L, () => interactor.GoToLastPage() },
                    { ConsoleKey.X, () => Exit() }
                };

                foreach (string line in interactor.GotToFirstPage())
                {
                    console.WriteLine(line);
                }

                while (true)
                {
                    console.WriteLine("N(ext page, P(revious page, F(irst page, L(ast page, eX(it");
                    ConsoleKey consoleKey = console.ReadKey().Key;

                    if (!commands.TryGetValue(consoleKey, out Func<IList<string>> command))
                    {
                        throw new NotSupportedException($"Key {consoleKey} is not supported");
                    }

                    foreach (string line in command.Invoke())
                    {
                        console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                console.WriteLine($"An error occured: {ex.Message}");
            }
        }

        private static IList<string> Exit()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
