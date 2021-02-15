using System.Collections.Generic;
using CsvViewer.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvTableRendererTests
    {
        private CsvTableRenderer CreateCsvRenderer() => new CsvTableRenderer(TestData.CsvTable);

        [Test]
        public void Should_Render_Second_Page()
        {
            // Arrange
            CsvTableRenderer csvRenderer = CreateCsvRenderer();
            var pageToRender = new Page(5, 10);

            // Act
            IList<string> result = csvRenderer.RenderCsv(pageToRender);

            // Assert
            result.Should().Equal(TestData.RenderedSecondPage);
        }
    }
}
