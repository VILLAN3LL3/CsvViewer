using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvInteractorTests
    {
        private CsvInteractor CreateCsvInteractor() => new CsvInteractor();

        [Test]
        public void Should_Integrate_Correctly()
        {
            // Arrange
            CsvInteractor csvInteractor = CreateCsvInteractor();
            string path = "addresses.csv";

            // Act
            IList<string> result = csvInteractor.GetRenderedCsvTableByPath(
                path);

            // Assert
            result.Should().Equals(TestData.RenderedCsvData);
        }
    }
}
