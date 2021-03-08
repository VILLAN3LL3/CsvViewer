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

                var incrementColumn = new CsvColumn { Header = "No." };
                new List<string> { "1.", "2.", "3.", "4.", "5.", "6.", "7.", "8.", "9.", "10.", "11.", "12." }.ForEach(age => incrementColumn.DataLines.Add(age));
                table.Columns.Add(incrementColumn);

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
            "+---+-----------+-----+-----------+",
            "|No.|Name       |Alter|Ort        |",
            "+---+-----------+-----+-----------+",
            "|1. |Paul       |27   |München    |",
            "+---+-----------+-----+-----------+",
            "|2. |Ina        |80   |Osnabrück  |",
            "+---+-----------+-----+-----------+",
            "|3. |Peter      |18   |Freiburg   |",
            "+---+-----------+-----+-----------+",
            "|4. |Britta     |26   |Rheinau    |",
            "+---+-----------+-----+-----------+",
            "|5. |Hilde      |90   |Neunkirchen|",
            "+---+-----------+-----+-----------+",
            "Page 1 of 3"
        };

        public static IList<string> RenderedLastPage => new List<string>
        {
            "+---+-----------+-----+-----------+",
            "|No.|Name       |Alter|Ort        |",
            "+---+-----------+-----+-----------+",
            "|11.|Meredith   |48   |London     |",
            "+---+-----------+-----+-----------+",
            "|12.|Erhard     |77   |Freising   |",
            "+---+-----------+-----+-----------+",
            "Page 3 of 3"
        };

        public static IList<string> RenderedSecondPage => new List<string>
        {
            "+---+-----------+-----+-----------+",
            "|No.|Name       |Alter|Ort        |",
            "+---+-----------+-----+-----------+",
            "|6. |Charlotte  |46   |Berlin     |",
            "+---+-----------+-----+-----------+",
            "|7. |Hans-Jürgen|68   |Essen      |",
            "+---+-----------+-----+-----------+",
            "|8. |Kuno       |78   |Basel      |",
            "+---+-----------+-----+-----------+",
            "|9. |Christian  |5    |Fulda      |",
            "+---+-----------+-----+-----------+",
            "|10.|Sarah      |34   |Cuxhaven   |",
            "+---+-----------+-----+-----------+",
            "Page 2 of 3"
        };
    }
}
