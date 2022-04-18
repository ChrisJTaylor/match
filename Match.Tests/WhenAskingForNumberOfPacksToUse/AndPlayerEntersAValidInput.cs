using System;
using System.IO;
using System.Text;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using static Match.Constants;

namespace Match.Tests.WhenAskingForNumberOfPacksToUse;

public class AndPlayerEntersAValidInput
{
    private StringBuilder _consoleOut;
    private int _numberOfPacks;

    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = new Mock<IKeyboardInput>();
        var number2 = new ConsoleKeyInfo('2', ConsoleKey.NumPad2, false, false, false);
        keyboardInput.Setup(key => key.ReceiveInput()).Returns(number2);
        
        _consoleOut = new StringBuilder();
        var consoleWriter = new StringWriter(_consoleOut);
        var playerInput = new PlayerInput(consoleWriter, keyboardInput.Object);
        
        _numberOfPacks = playerInput.AskPlayerHowManyPacksOfCardsToUse();
    }

    [Test]
    public void ItShouldAskThePlayerTheExpectedQuestion()
    {
        _consoleOut.ToString().Should().Contain(HowManyPacksOfCardsToUse);
    }

    [Test]
    public void ItShouldReturnTheExpectedNumber()
    {
        _numberOfPacks.Should().Be(2);
    }
}