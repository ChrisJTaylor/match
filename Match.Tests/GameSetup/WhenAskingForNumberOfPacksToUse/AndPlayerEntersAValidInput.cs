using Match.Domain.GameControls;
using static Match.Domain.GameControls.Constants.Questions;
using static Match.Tests.TestHelpers.KeyboardInputHelperExtensions;

namespace Match.Tests.GameSetup.WhenAskingForNumberOfPacksToUse;

using TestHelpers;

public class AndPlayerEntersAValidInput
{
    private readonly StringBuilder _consoleOut = new();
    private int _numberOfPacks;

    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = Given.Create<Mock<IKeyboardInput>>().ThatPressesKey('2'); 

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