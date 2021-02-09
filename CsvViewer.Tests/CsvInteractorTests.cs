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
        public void Interact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            CsvInteractor csvInteractor = CreateCsvInteractor();
            string path = "addresses.csv";

            // Act
            IList<string> result = csvInteractor.Interact(
                path);

            // Assert
            result.Should().BeEquivalentTo(TestData.RenderedCsvData);
        }
    }
}
