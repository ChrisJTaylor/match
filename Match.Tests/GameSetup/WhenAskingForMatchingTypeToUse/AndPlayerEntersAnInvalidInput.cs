using System;
using System.IO;
using System.Text;
using AutoFixture;
using FluentAssertions;
using Match.Domain.GameControls;
using Moq;
using NUnit.Framework;
using static Match.Domain.GameControls.Constants.Questions;
using static Match.Domain.GameControls.Constants.Responses;
using static Match.Tests.GameSetup.TestHelpers.KeyboardInputHelperExtensions;

namespace Match.Tests.GameSetup.WhenAskingForMatchingTypeToUse;

public class AndPlayerEntersAnInvalidInput
{
    private readonly StringBuilder _consoleOut = new();
    private Exception? _caughtException;
    
    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = new Mock<IKeyboardInput>();
        keyboardInput.Setup(key => key.ReceiveInput()).Returns(KeyFor('Y'));

        var fixture = new Fixture();
        fixture.Register(() => keyboardInput.Object);
        fixture.Register<TextWriter>(() => new StringWriter(_consoleOut));
        var playerInput = fixture.Create<PlayerInput>(); 

        try
        {
            _ = playerInput.AskPlayerWhichMatchingConditionToUse();
        }
        catch (Exception e)
        {
            _caughtException = e;
        }
    }

    [Test]
    public void ItShouldAskThePlayerTheExpectedQuestion()
    {
        _consoleOut.ToString().Should().Contain(WhichMatchingConditionWouldYouLikeToUse);
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
        _caughtException!.Message.Should().Be(YouMustEnterANumberBetween1And3);
    }
}