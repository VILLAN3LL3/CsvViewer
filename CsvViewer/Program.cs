using System;

namespace CsvViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new CsvReader();
            Console.WriteLine("Geben Sie den Pfad zu einem CSV File an");
            var path = Console.ReadLine();
            var lines = reader.ReadCsv(path);
            foreach (var line in lines)
            {
                foreach (var column in line)
                {
                    Console.Write(column + " - ");
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
