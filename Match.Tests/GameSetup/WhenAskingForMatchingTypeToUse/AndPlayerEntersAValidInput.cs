using System;
using System.IO;
using System.Text;
using FluentAssertions;
using Match.Domain;
using Match.Domain.GameControls;
using Match.Domain.GameRoutine;
using Moq;
using NUnit.Framework;
using static Match.Domain.GameControls.Constants.Questions;

namespace Match.Tests.GameSetup.WhenAskingForMatchingTypeToUse;

public class AndPlayerEntersAValidInput
{
    private StringBuilder _consoleOut = new ();
    private MatchingCondition _matchingType;

    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = new Mock<IKeyboardInput>();
        var number3 = new ConsoleKeyInfo('3', ConsoleKey.NumPad3, false, false, false);
        keyboardInput.Setup(key => key.ReceiveInput()).Returns(number3);
        
        _consoleOut = new StringBuilder();
        var consoleWriter = new StringWriter(_consoleOut);
        var playerInput = new PlayerInput(consoleWriter, keyboardInput.Object);
        
        _matchingType = playerInput.AskPlayerWhichMatchingConditionToUse();
    }

    [Test]
    public void ItShouldAskThePlayerTheExpectedQuestion()
    {
        _consoleOut.ToString().Should().Contain(WhichMatchingConditionWouldYouLikeToUse);
    }

    [Test]
    public void ItShouldReturnTheExpectedMatchingType()
    {
        _matchingType.Should().Be(MatchingCondition.CardValueAndSuit);
    }
}