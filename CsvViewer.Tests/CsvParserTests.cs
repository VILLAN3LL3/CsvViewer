using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvParserTests
    {
        private CsvParser CreateCsvParser() => new CsvParser();

        [Test]
        public void Should_Parse_Csv_Correctly()
        {
            // Arrange
            CsvParser csvParser = CreateCsvParser();
            IList<string[]> csvContent = TestData.CsvContent;

            // Act
            CsvTable result = csvParser.ParseCsv(
                csvContent);

            // Assert
            result.Should().BeEquivalentTo(TestData.CsvTable);
        }
    }
}
