using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvTableRendererTests
    {
        private CsvTableRenderer CreateCsvRenderer() => new CsvTableRenderer(TestData.CsvTable);

        [Test]
        public void Should_Render_First_Page()
        {
            // Arrange
            CsvTableRenderer csvRenderer = CreateCsvRenderer();

            // Act
            IList<string> result = csvRenderer.RenderFirstPage();

            // Assert
            result.Should().Equal(TestData.RenderedFirstPage);
        }

        [Test]
        public void Should_Render_Last_Page()
        {
            // Arrange
            CsvTableRenderer csvRenderer = CreateCsvRenderer();

            // Act
            IList<string> result = csvRenderer.RenderLastPage();

            // Assert
            result.Should().Equal(TestData.RenderedLastPage);
        }

        [Test]
        public void Should_Render_Next_Page()
        {
            // Arrange
            CsvTableRenderer csvRenderer = CreateCsvRenderer();

            // Act
            IList<string> result = csvRenderer.RenderNextPage();

            // Assert
            result.Should().Equal(TestData.RenderedSecondPage);
        }

        [Test]
        public void Should_Render_Previous_Page()
        {
            // Arrange
            CsvTableRenderer csvRenderer = CreateCsvRenderer();

            // Act
            IList<string> result = csvRenderer.RenderPreviousPage();

            // Assert
            result.Should().Equal(TestData.RenderedLastPage);
        }
    }
}
