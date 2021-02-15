using System;
using System.Collections.Generic;
using CsvViewer.Model;

namespace CsvViewer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CommandLineArg arguments = GetCommandLineArgs(args);
            Console.WriteLine($"I will now display the first page of the csv table on path {arguments.Path} with a maximum page size of {arguments.PageSize}:");

            try
            {
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
                    Console.WriteLine(line);
                }

                while (true)
                {
                    Console.WriteLine("N(ext page, P(revious page, F(irst page, L(ast page, eX(it");
                    ConsoleKey consoleKey = Console.ReadKey().Key;

                    if (!commands.TryGetValue(consoleKey, out Func<IList<string>> command))
                    {
                        throw new NotSupportedException($"Key {consoleKey} is not supported");
                    }

                    foreach (string line in command.Invoke())
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }

        private static CommandLineArg GetCommandLineArgs(string[] args)
        {
            return new CommandLineArg
            {
                Path = GetPath(args),
                PageSize = GetPageSize(args)
            };
        }

        private static string GetPath(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter the path to the csv file you want to display");
                return Console.ReadLine();
            }
            else
            {
                return args[0];
            }
        }

        private static int GetPageSize(string[] args)
        {
            string pageSizeString;
            if (args.Length < 2)
            {
                Console.WriteLine("Please enter the page size");
                pageSizeString = Console.ReadLine();
            }
            else
            {
                pageSizeString = args[1];
            }

            if (!int.TryParse(pageSizeString, out int pageSize))
            {
                throw new ArgumentOutOfRangeException($"'{pageSize}' is not a valid value for the page size");
            }
            return pageSize;
        }

        private static IList<string> Exit()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
