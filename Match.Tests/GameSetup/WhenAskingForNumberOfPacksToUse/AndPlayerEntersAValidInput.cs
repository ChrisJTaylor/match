using System.IO;
using System.Text;
using AutoFixture;
using FluentAssertions;
using Match.Domain.GameControls;
using Moq;
using NUnit.Framework;
using static Match.Domain.GameControls.Constants.Questions;
using static Match.Tests.GameSetup.TestHelpers.KeyboardInputHelperExtensions;

namespace Match.Tests.GameSetup.WhenAskingForNumberOfPacksToUse;

public class AndPlayerEntersAValidInput
{
    private readonly StringBuilder _consoleOut = new();
    private int _numberOfPacks;

    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = new Mock<IKeyboardInput>();
        keyboardInput.Setup(key => key.ReceiveInput()).Returns(KeyFor('2'));

        var fixture = new Fixture();
        fixture.Register(() => keyboardInput.Object);
        fixture.Register<TextWriter>(() => new StringWriter(_consoleOut));
        var playerInput = fixture.Create<PlayerInput>(); 
        
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