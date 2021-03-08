using System;
using CsvViewer.Model;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace CsvViewer.Tests
{
    [TestFixture]
    public class CommandLineArgsHandlerTests
    {
        private IConsole _subConsole;
        private readonly string _validPath = "some/path/to/file.csv";
        private readonly string _validPageSizeString = "3";
        private readonly int _validPageSize = 3;

        [SetUp]
        public void SetUp() => _subConsole = Substitute.For<IConsole>();

        private CommandLineArgsHandler CreateCommandLineArgsHandler() => new CommandLineArgsHandler(
                _subConsole);

        [Test]
        public void Should_Get_CommandLineArgs_From_Valid_Args()
        {
            // Arrange
            CommandLineArgsHandler commandLineArgsHandler = CreateCommandLineArgsHandler();
            string[] args = new[] { _validPath, _validPageSizeString };
            var expectedResult = new CommandLineArg(_validPath, _validPageSize);

            // Act
            CommandLineArg result = commandLineArgsHandler.GetCommandLineArgs(
                args);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void Should_Throw_Exception_If_Invalid_PageSize_Is_Supplied()
        {
            // Arrange
            CommandLineArgsHandler commandLineArgsHandler = CreateCommandLineArgsHandler();
            string[] args = new[] { _validPath, "R" };

            // Act
            Func<CommandLineArg> func = () => commandLineArgsHandler.GetCommandLineArgs(args);

            // Assert
            func.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("'R' is not a valid value for the page size (Parameter 'pageSizeString')");
        }

        [Test]
        public void Should_Read_Console_If_No_PageSize_Is_Supplied()
        {
            // Arrange
            CommandLineArgsHandler commandLineArgsHandler = CreateCommandLineArgsHandler();
            string[] args = new[] { _validPath };
            _subConsole.ReadLine().Returns("5");
            var expectedResult = new CommandLineArg(_validPath, 5);

            // Act
            CommandLineArg result = commandLineArgsHandler.GetCommandLineArgs(
                args);

            // Assert
            result.Should().Be(expectedResult);
            _subConsole.Received(1).WriteLine("Please enter the page size");
            _subConsole.Received(1).ReadLine();
        }

        private static object[] _emptyArgsTestCases =
        {
            new object[] { Array.Empty<string>() },
            new object[] { null }
        };

        [Test]
        [TestCaseSource(nameof(_emptyArgsTestCases))]
        public void Should_Read_Console_If_Args_Are_Empty_Or_Null(string[] args)
        {
            // Arrange
            CommandLineArgsHandler commandLineArgsHandler = CreateCommandLineArgsHandler();
            _subConsole.ReadLine().Returns(_validPath, _validPageSizeString);
            var expectedResult = new CommandLineArg(_validPath, _validPageSize);

            // Act
            CommandLineArg result = commandLineArgsHandler.GetCommandLineArgs(
                args);

            // Assert
            result.Should().Be(expectedResult);
            _subConsole.Received(1).WriteLine("Please enter the page size");
            _subConsole.Received(1).WriteLine("Please enter the path to the csv file you want to display");
            _subConsole.Received(2).ReadLine();
        }
    }
}
