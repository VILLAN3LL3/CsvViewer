using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CsvInteractorTests
    {
        private CsvInteractor CreateCsvInteractor() => new CsvInteractor("addresses.csv");

        [Test]
        public void Should_Go_To_First_Page()
        {
            // Arrange
            CsvInteractor csvInteractor = CreateCsvInteractor();

            // Act
            IList<string> result = csvInteractor.GotToFirstPage();

            // Assert
            result.Should().Equals(TestData.RenderedFirstPage);
        }

        [Test]
        public void Should_Go_To_Last_Page()
        {
            // Arrange
            CsvInteractor csvInteractor = CreateCsvInteractor();

            // Act
            IList<string> result = csvInteractor.GoToLastPage();

            // Assert
            result.Should().Equals(TestData.RenderedLastPage);
        }

        [Test]
        public void Should_Go_To_Next_Page()
        {
            // Arrange
            CsvInteractor csvInteractor = CreateCsvInteractor();

            // Act
            IList<string> result = csvInteractor.GoToLastPage();

            // Assert
            result.Should().Equals(TestData.RenderedSecondPage);
        }

        [Test]
        public void Should_Go_To_Previous_Page()
        {
            // Arrange
            CsvInteractor csvInteractor = CreateCsvInteractor();

            // Act
            IList<string> result = csvInteractor.GoToPreviousPage();

            // Assert
            result.Should().Equals(TestData.RenderedLastPage);
        }
    }
}
