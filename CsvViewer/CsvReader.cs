using System.Collections.Generic;
using System.IO;

namespace CsvViewer
{
    public class CsvReader
    {
        public IList<string[]> ReadCsv(string path)
        {
            if (path is null)
            {
                throw new System.ArgumentNullException(nameof(path));
            }

            var lineValues = new List<string[]>();

            using var streamReader = new StreamReader(File.OpenRead(path));
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                var values = line.Split(';');
                if (values.Length > 0)
                {
                    lineValues.Add(values);
                }
            }
            return lineValues;
        }
    }
}
