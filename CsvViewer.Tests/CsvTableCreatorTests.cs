using CsvViewer.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvTableCreatorTests
    {
        private CsvTableCreator CreateCsvParser() => new CsvTableCreator();

        [Test]
        public void Should_Create_Csv_Table()
        {
            // Arrange
            CsvTableCreator csvParser = CreateCsvParser();
            string[] csvContent = TestData.CsvContent;
            var expectedTable = TestData.CsvTable;

            // Act
            CsvTable result = csvParser.CreateCsvTable(
                csvContent);

            // Assert
            result.Should().BeEquivalentTo(expectedTable, opt => opt.ComparingByMembers<CsvTable>().Excluding(t => t.Columns));
            result.Columns.Should().BeEquivalentTo(expectedTable.Columns, opt => opt.ComparingByMembers<CsvColumn>());
        }
    }
}
