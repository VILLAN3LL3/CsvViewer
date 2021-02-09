using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvReaderTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private CsvReader CreateCsvReader() => new CsvReader();

        [Test]
        public void Should_Read_CSV_Correctly()
        {
            // Arrange
            CsvReader csvReader = CreateCsvReader();
            string path = "addresses.csv";
            var expectedResult = new List<string[]>
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

            // Act
            IList<string[]> result = csvReader.ReadCsv(
                path);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
