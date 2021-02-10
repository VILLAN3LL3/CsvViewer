using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvTableRendererTests
    {
        private CsvTableRenderer CreateCsvRenderer() => new CsvTableRenderer();

        [Test]
        public void Should_Render_Csv_Correctly()
        {
            // Arrange
            CsvTableRenderer csvRenderer = CreateCsvRenderer();
            CsvTable csvTable = TestData.CsvTable;

            // Act
            IList<string> result = csvRenderer.RenderCsv(
                csvTable);

            // Assert
            result.Should().Equal(TestData.RenderedCsvData);
        }
    }
}
