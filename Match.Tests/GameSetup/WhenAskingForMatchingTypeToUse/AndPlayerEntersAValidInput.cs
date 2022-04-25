using System.IO;
using System.Text;
using AutoFixture;
using FluentAssertions;
using Match.Domain.GameControls;
using Match.Domain.GameRoutine;
using Moq;
using NUnit.Framework;
using static Match.Domain.GameControls.Constants.Questions;
using static Match.Tests.GameSetup.TestHelpers.KeyboardInputHelperExtensions;

namespace Match.Tests.GameSetup.WhenAskingForMatchingTypeToUse;

public class AndPlayerEntersAValidInput
{
    private readonly StringBuilder _consoleOut = new ();
    private MatchingCondition _matchingType;

    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = new Mock<IKeyboardInput>();
        keyboardInput.Setup(key => key.ReceiveInput()).Returns(KeyFor('3'));

        var fixture = new Fixture();
        fixture.Register(() => keyboardInput.Object);
        fixture.Register<TextWriter>(() => new StringWriter(_consoleOut));
        var playerInput = fixture.Create<PlayerInput>(); 
        
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