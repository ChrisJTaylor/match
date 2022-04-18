using System;
using System.IO;
using System.Text;
using FluentAssertions;
using Match.Domain;
using Moq;
using NUnit.Framework;
using static Match.Domain.Constants;

namespace Match.Tests.WhenAskingForMatchingTypeToUse;

public class AndPlayerEntersAnInvalidInput
{
    private StringBuilder _consoleOut;

    private Exception _caughtException;
    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = new Mock<IKeyboardInput>();
        var letterY = new ConsoleKeyInfo('Y', ConsoleKey.Y, false, false, false);
        keyboardInput.Setup(key => key.ReceiveInput()).Returns(letterY);
        
        _consoleOut = new StringBuilder();
        var consoleWriter = new StringWriter(_consoleOut);
        var playerInput = new PlayerInput(consoleWriter, keyboardInput.Object);

        try
        {
            _ = playerInput.AskPlayerWhichMatchingTypeToUse();
        }
        catch (Exception e)
        {
            _caughtException = e;
        }
    }

    [Test]
    public void ItShouldAskThePlayerTheExpectedQuestion()
    {
        _consoleOut.ToString().Should().Contain(WhichMatchingTypeWouldYouLikeToUse);
    }

    [Test]
    public void ItShouldThrowTheExpectedException()
    {
        _caughtException.Should().NotBeNull();
        _caughtException.Should().BeOfType<InvalidInputException>();
    }
    
    [Test]
    public void TheExceptionShouldHaveTheExpectedMessage()
    {
        _caughtException.Message.Should().Be(YouMustEnterANumberBetween1And3);
    }
}