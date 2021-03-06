﻿using CsvViewer.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class PageCalculatorTests
    {
        private PageCalculator CreatePageCalculator(int initialOffset) => new PageCalculator(TestData.CsvTable.DataLinesCount, 5, initialOffset);

        [Test]
        public void Should_Calculate_First_Page()
        {
            // Arrange
            PageCalculator pageCalculator = CreatePageCalculator(0);
            var expectedPage = new Page(0, 5, 1, 3);

            // Act
            Page result = pageCalculator.CalculateFirstPage();

            // Assert
            result.Should().BeEquivalentTo(expectedPage);
            pageCalculator.CurrentOffset.Should().Be(0);
        }

        [Test]
        public void Should_Calculate_Last_Page()
        {
            // Arrange
            PageCalculator pageCalculator = CreatePageCalculator(0);
            var expectedPage = new Page(10, 12, 3, 3);

            // Act
            Page result = pageCalculator.CalculateLastPage();

            // Assert
            result.Should().BeEquivalentTo(expectedPage);
            pageCalculator.CurrentOffset.Should().Be(10);
        }

        [Test]
        public void Should_Calculate_Next_Page()
        {
            // Arrange
            PageCalculator pageCalculator = CreatePageCalculator(0);
            var expectedPage = new Page(5, 10, 2, 3);

            // Act
            Page result = pageCalculator.CalculateNextPage();

            // Assert
            result.Should().BeEquivalentTo(expectedPage);
            pageCalculator.CurrentOffset.Should().Be(5);
        }

        [Test]
        public void Should_Calculate_First_Page_If_Next_Page_Does_Not_Exist()
        {
            // Arrange
            PageCalculator pageCalculator = CreatePageCalculator(10);
            var expectedPage = new Page(0, 5, 1, 3);

            // Act
            Page result = pageCalculator.CalculateNextPage();

            // Assert
            result.Should().BeEquivalentTo(expectedPage);
            pageCalculator.CurrentOffset.Should().Be(0);
        }

        [Test]
        public void Should_Calculate_Previous_Page()
        {
            // Arrange
            PageCalculator pageCalculator = CreatePageCalculator(5);
            var expectedPage = new Page(0, 5, 1, 3);

            // Act
            Page result = pageCalculator.CalculatePreviousPage();

            // Assert
            result.Should().BeEquivalentTo(expectedPage);
            pageCalculator.CurrentOffset.Should().Be(0);
        }

        [Test]
        public void Should_Calculate_Last_Page_If_Previous_Page_Does_Not_Exist()
        {
            // Arrange
            PageCalculator pageCalculator = CreatePageCalculator(0);
            var expectedPage = new Page(10, 12, 3, 3);

            // Act
            Page result = pageCalculator.CalculatePreviousPage();

            // Assert
            result.Should().BeEquivalentTo(expectedPage);
            pageCalculator.CurrentOffset.Should().Be(10);
        }

        [Test]
        public void Should_Calculate_Page_By_PageNumber()
        {
            // Arrange
            PageCalculator pageCalculator = CreatePageCalculator(5);
            var expectedPage = new Page(5, 10, 2, 3);

            // Act
            Page result = pageCalculator.CalculatePage(2);

            // Assert
            result.Should().BeEquivalentTo(expectedPage);
            pageCalculator.CurrentOffset.Should().Be(5);
        }

        [Test]
        public void Should_Calculate_Last_Page_If_PageNumber_Exceeds_Total_Pages()
        {
            // Arrange
            PageCalculator pageCalculator = CreatePageCalculator(0);
            var expectedPage = new Page(10, 12, 3, 3);

            // Act
            Page result = pageCalculator.CalculatePage(5);

            // Assert
            result.Should().BeEquivalentTo(expectedPage);
            pageCalculator.CurrentOffset.Should().Be(10);
        }

        [Test]
        public void Should_Calculate_First_Page_If_PageNumber_Is_Less_Than_1()
        {
            // Arrange
            PageCalculator pageCalculator = CreatePageCalculator(10);
            var expectedPage = new Page(0, 5, 1, 3);

            // Act
            Page result = pageCalculator.CalculatePage(0);

            // Assert
            result.Should().BeEquivalentTo(expectedPage);
            pageCalculator.CurrentOffset.Should().Be(0);
        }
    }
}
