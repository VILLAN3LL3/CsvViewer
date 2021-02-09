using System;

namespace CsvViewer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie den Pfad zu einem CSV File an");
            string path = Console.ReadLine();

            var interactor = new CsvInteractor();
            foreach (string line in interactor.Interact(path))
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
        }
    }
}
