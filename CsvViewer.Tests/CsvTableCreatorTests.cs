using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvTableCreatorTests
    {
        private CsvTableCreator CreateCsvParser() => new CsvTableCreator();

        [Test]
        public void Should_Parse_Csv_Correctly()
        {
            // Arrange
            CsvTableCreator csvParser = CreateCsvParser();
            string[] csvContent = TestData.CsvContent;

            // Act
            CsvTable result = csvParser.CreateCsvTable(
                csvContent);

            // Assert
            result.Should().Equals(TestData.CsvTable);
        }
    }
}
