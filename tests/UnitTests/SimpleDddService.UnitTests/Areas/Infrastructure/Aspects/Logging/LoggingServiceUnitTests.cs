using System;
using FluentAssertions;
using Moq;
using SimpleDddService.Infrastructure.Aspects.Logging.Handlers;
using SimpleDddService.Infrastructure.Aspects.Logging.Implementation;
using SimpleDddService.Infrastructure.DomainExtensions.Invariance;
using Xunit;

namespace SimpleDddService.UnitTests.Areas.Infrastructure.Aspects.Logging
{
    public class LoggingServiceUnitTests
    {
        private readonly Mock<ILoggerProxy> _loggerProxyMock;
        private readonly LoggingService _sut;

        public LoggingServiceUnitTests()
        {
            _loggerProxyMock = new Mock<ILoggerProxy>();
            _sut = new LoggingService(_loggerProxyMock.Object);
        }

        [Fact]
        public void LoggingException_WithException_LogsErrorWithExceptionMessageOnce()
        {
            // Given
            var exception = new Exception("Tra");

            // When
            _sut.LogException(exception);

            // Then
            _loggerProxyMock.Verify(f => f.LogError(exception, exception.Message), Times.Once);
        }

        [Fact]
        public void LoggingException_WithNullException_ThrowsArgumentExceptionWithParametername()
        {
            // Given
            Exception nullException = null;
            var expectedExceptionMessage = string.Format(Guard.NullObjectExceptionMessage, "ex");

            // When
            var actualException = Assert.Throws<ArgumentException>(() => _sut.LogException(nullException));

            // Then
            actualException.Should().BeOfType<ArgumentException>();
            actualException.Message.Should().Be(expectedExceptionMessage);
        }

        [Fact]
        public void LoggingInformation_WithInfoMessage_LogsAsInformationOnce()
        {
            // Given
            const string InfoMessage = "Information123";

            // When
            _sut.LogInfo(InfoMessage);

            // Then
            _loggerProxyMock.Verify(f => f.LogInformation(InfoMessage), Times.Once);
        }

        [Fact]
        public void LoggingWarning_WithEmptyWarningMessage_ThrowsArgumentExceptionWithParametername()
        {
            // Given
            const string EmptyWarningMessage = "";
            var expectedExceptionMessage = string.Format(Guard.StringNullOrEmptyExceptionMessage, "message");

            // When
            var actualException = Assert.Throws<ArgumentException>(() => _sut.LogWarning(EmptyWarningMessage));

            // Then
            actualException.Should().BeOfType<ArgumentException>();
            actualException.Message.Should().Be(expectedExceptionMessage);
        }

        [Fact]
        public void LoggingWarning_WithWarningMessage_LogsWarningOnce()
        {
            // Given
            const string WarningMessage = "Warning123";

            // When
            _sut.LogWarning(WarningMessage);

            // Then
            _loggerProxyMock.Verify(f => f.LogWarning(WarningMessage), Times.Once);
        }
    }
}