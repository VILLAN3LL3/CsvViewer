using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvReaderTests
    {
        private CsvReader CreateCsvReader() => new CsvReader();

        [Test]
        public void Should_Read_CSV_Correctly()
        {
            // Arrange
            CsvReader csvReader = CreateCsvReader();
            string path = "addresses.csv";

            // Act
            string[] result = csvReader.ReadCsv(
                path);

            // Assert
            result.Should().BeEquivalentTo(TestData.CsvContent);
        }
    }
}
