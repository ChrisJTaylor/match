using System;
using System.IO;
using System.Text;
using FluentAssertions;
using Match.Domain;
using Moq;
using NUnit.Framework;
using static Match.Domain.Constants;

namespace Match.Tests.WhenAskingForMatchingTypeToUse;

public class AndPlayerEntersAValidInput
{
    private StringBuilder _consoleOut;
    private MatchingTypeEnum _matchingType;

    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = new Mock<IKeyboardInput>();
        var number3 = new ConsoleKeyInfo('3', ConsoleKey.NumPad3, false, false, false);
        keyboardInput.Setup(key => key.ReceiveInput()).Returns(number3);
        
        _consoleOut = new StringBuilder();
        var consoleWriter = new StringWriter(_consoleOut);
        var playerInput = new PlayerInput(consoleWriter, keyboardInput.Object);
        
        _matchingType = playerInput.AskPlayerWhichMatchingTypeToUse();
    }

    [Test]
    public void ItShouldAskThePlayerTheExpectedQuestion()
    {
        _consoleOut.ToString().Should().Contain(WhichMatchingTypeWouldYouLikeToUse);
    }

    [Test]
    public void ItShouldReturnTheExpectedMatchingType()
    {
        _matchingType.Should().Be(MatchingTypeEnum.CardValueAndSuit);
    }
}