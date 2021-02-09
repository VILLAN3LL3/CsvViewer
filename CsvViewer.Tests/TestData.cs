using System.Collections.Generic;
using CsvViewer.Model;

namespace CsvViewer.Tests
{
    public static class TestData
    {
        public static string[] CsvContent => new string[]
            {
                "Name;Alter;Ort",
                "Paul;27;München",
                "Ina;80;Osnabrück",
                "Peter;18;Freiburg",
                "Britta;26;Rheinau",
                "Hilde;90;Neunkirchen",
                "Charlotte;46;Berlin",
                "Hans-Jürgen;68;Essen",
                "Kuno;78;Basel",
                "Christian;5;Fulda",
                "Sarah;34;Cuxhaven",
            };

        public static CsvTable CsvTable
        {
            get
            {
                var table = new CsvTable();
                table.Columns = new List<CsvColumn>()
                {
                    new CsvColumn { Header = "Name", DataLines = new List<string> { "Paul", "Ina", "Peter", "Britta", "Hilde", "Charlotte", "Hans-Jürgen", "Kuno", "Christian", "Sarah" }},
                    new CsvColumn { Header = "Alter", DataLines = new List<string> { "27", "80", "18", "26", "90", "46", "68", "78", "5", "34"}},
                    new CsvColumn { Header = "Ort", DataLines = new List<string> { "München", "Osnabrück", "Freiburg", "Rheinau", "Neunkirchen", "Berlin", "Essen", "Basel", "Fulda", "Cuxhaven"}}
                };
                return table;
            }
        }

        public static IList<string> RenderedCsvData => new List<string>
        {
            "+-----------+-----+-----------+",
            "|Name       |Alter|Ort        |",
            "+-----------+-----+-----------+",
            "|Paul       |27   |München    |",
            "+-----------+-----+-----------+",
            "|Ina        |80   |Osnabrück  |",
            "+-----------+-----+-----------+",
            "|Peter      |18   |Freiburg   |",
            "+-----------+-----+-----------+",
            "|Britta     |26   |Rheinau    |",
            "+-----------+-----+-----------+",
            "|Hilde      |90   |Neunkirchen|",
            "+-----------+-----+-----------+",
            "|Charlotte  |46   |Berlin     |",
            "+-----------+-----+-----------+",
            "|Hans-Jürgen|68   |Essen      |",
            "+-----------+-----+-----------+",
            "|Kuno       |78   |Basel      |",
            "+-----------+-----+-----------+",
            "|Christian  |5    |Fulda      |",
            "+-----------+-----+-----------+",
            "|Sarah      |34   |Cuxhaven   |",
            "+-----------+-----+-----------+",
        };
    }
}
