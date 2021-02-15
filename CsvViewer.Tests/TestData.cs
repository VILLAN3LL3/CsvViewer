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
                "Meredith;48;London",
                "Erhard;77;Freising"
            };

        public static CsvTable CsvTable
        {
            get
            {
                var table = new CsvTable();
                var nameColumn = new CsvColumn { Header = "Name" };
                new List<string> { "Paul", "Ina", "Peter", "Britta", "Hilde", "Charlotte", "Hans-Jürgen", "Kuno", "Christian", "Sarah", "Meredith", "Erhard" }.ForEach(name => nameColumn.DataLines.Add(name));
                table.Columns.Add(nameColumn);

                var ageColumn = new CsvColumn { Header = "Alter" };
                new List<string> { "27", "80", "18", "26", "90", "46", "68", "78", "5", "34", "48", "77" }.ForEach(age => ageColumn.DataLines.Add(age));
                table.Columns.Add(ageColumn);

                var townColumn = new CsvColumn { Header = "Ort" };
                new List<string> { "München", "Osnabrück", "Freiburg", "Rheinau", "Neunkirchen", "Berlin", "Essen", "Basel", "Fulda", "Cuxhaven", "London", "Freising" }.ForEach(town => townColumn.DataLines.Add(town));
                table.Columns.Add(townColumn);

                return table;
            }
        }

        public static IList<string> RenderedFirstPage => new List<string>
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
        };

        public static IList<string> RenderedLastPage => new List<string>
        {
            "+-----------+-----+-----------+",
            "|Name       |Alter|Ort        |",
            "+-----------+-----+-----------+",
            "|Meredith   |48   |London     |",
            "+-----------+-----+-----------+",
            "|Erhard     |77   |Freising   |",
            "+-----------+-----+-----------+",
        };

        public static IList<string> RenderedSecondPage => new List<string>
        {
            "+-----------+-----+-----------+",
            "|Name       |Alter|Ort        |",
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
