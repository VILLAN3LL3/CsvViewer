using System;

namespace CsvViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie den Pfad zu einem CSV File an");
            var path = Console.ReadLine();

            var interactor = new CsvInteractor();
            foreach (var line in interactor.Interact(path))
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
        }
    }
}
