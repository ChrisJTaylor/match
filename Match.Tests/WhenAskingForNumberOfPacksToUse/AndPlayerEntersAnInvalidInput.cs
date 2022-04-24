using System;
using System.IO;
using System.Text;
using FluentAssertions;
using Match.GameControls;
using Moq;
using NUnit.Framework;
using static Match.GameControls.Constants.Questions;
using static Match.GameControls.Constants.Responses;

namespace Match.Tests.WhenAskingForNumberOfPacksToUse;

public class AndPlayerEntersAnInvalidInput
{
    private StringBuilder _consoleOut;
    private Exception _caughtException;
    
    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = new Mock<IKeyboardInput>();
        var letterX = new ConsoleKeyInfo('x', ConsoleKey.X, false, false, false);
        keyboardInput.Setup(key => key.ReceiveInput()).Returns(letterX);
        
        _consoleOut = new StringBuilder();
        var consoleWriter = new StringWriter(_consoleOut);
        var playerInput = new PlayerInput(consoleWriter, keyboardInput.Object);

        try
        {
            _ = playerInput.AskPlayerHowManyPacksOfCardsToUse();
        }
        catch (Exception e)
        {
            _caughtException = e;
        }
    }

    [Test]
    public void ItShouldAskThePlayerTheExpectedQuestion()
    {
        _consoleOut.ToString().Should().Contain(HowManyPacksOfCardsToUse);
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
        _caughtException.Message.Should().Be(YouMustEnterANumberBetween1And9);
    }
}