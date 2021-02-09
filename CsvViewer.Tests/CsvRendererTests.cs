using System.Collections.Generic;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvRendererTests
    {
        private CsvRenderer CreateCsvRenderer() => new CsvRenderer();

        [Test]
        public void Should_Render_Csv_Correctly()
        {
            // Arrange
            CsvRenderer csvRenderer = CreateCsvRenderer();
            CsvTable csvTable = TestData.CsvTable;

            // Act
            IList<string> result = csvRenderer.RenderCsv(
                csvTable);

            // Assert
            Assert.Fail();
        }
    }
}
