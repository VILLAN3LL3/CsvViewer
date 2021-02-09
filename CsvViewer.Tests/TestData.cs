using System.Collections.Generic;
using CsvViewer.Model;

namespace CsvViewer.Tests
{
    public static class TestData
    {
        public static IList<string[]> CsvContent => new List<string[]>
            {
                new string[] { "Name", "Alter", "Ort"},
                new string[] { "Paul", "27", "München"},
                new string[] { "Ina", "80", "Osnabrück"},
                new string[] { "Peter", "18", "Freiburg"},
                new string[] { "Britta", "26", "Rheinau"},
                new string[] { "Hilde", "90", "Neunkirchen"},
                new string[] { "Charlotte", "46", "Berlin"},
                new string[] { "Hans-Jürgen", "68", "Essen"},
                new string[] { "Kuno", "78", "Basel"},
                new string[] { "Christian", "5", "Fulda"},
                new string[] { "Sarah", "34", "Cuxhaven"},
            };

        public static CsvTable CsvTable
        {
            get
            {
                var table = new CsvTable();
                var columns = new List<CsvColumn>()
                {
                    new CsvColumn { Header = "Name", DataLines = new List<string> { "Paul", "Ina", "Peter", "Britta", "Hilde", "Charlotte", "Hans-Jürgen", "Kuno", "Christian", "Sarah" }},
                    new CsvColumn { Header = "Alter", DataLines = new List<string> { "27", "80", "18", "26", "90", "46", "68", "78", "5", "34"}},
                    new CsvColumn { Header = "Ort", DataLines = new List<string> { "München", "Osnabrück", "Freiburg", "Rheinau", "Neunkirchen", "Berlin", "Essen", "Basel", "Fulda", "Cuxhaven"}}
                };
                table.Columns = columns;
                return table;
            }
        }
    }
}
