using Match.Domain.GameControls;
using static Match.Domain.GameControls.Constants.Questions;
using static Match.Domain.GameControls.Constants.Responses;
using static Match.Tests.TestHelpers.KeyboardInputHelperExtensions;

namespace Match.Tests.GameSetup.WhenAskingForNumberOfPacksToUse;

using TestHelpers;

public class AndPlayerEntersAValidInputOutOfExpectedRange
{
    private readonly StringBuilder _consoleOut = new();
    private Exception? _caughtException;
    
    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = Given.Create<Mock<IKeyboardInput>>().ThatPressesKey('0'); 

        var fixture = new Fixture();
        fixture.Register(() => keyboardInput.Object);
        fixture.Register<TextWriter>(() => new StringWriter(_consoleOut));
        var playerInput = fixture.Create<PlayerInput>(); 

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
        _caughtException!.Message.Should().Be(YouMustEnterANumberBetween1And9);
    }
}