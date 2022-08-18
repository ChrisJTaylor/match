using Match.Domain.GameControls;
using static Match.Domain.GameControls.Constants.Questions;
using static Match.Tests.TestHelpers.KeyboardInputHelperExtensions;

namespace Match.Tests.GameSetup.WhenAskingForMatchingTypeToUse;

using TestHelpers;

public class AndPlayerEntersAValidInput
{
    private readonly StringBuilder _consoleOut = new ();
    private MatchingCondition _matchingType;

    [OneTimeSetUp]
    public void Setup()
    {
        var keyboardInput = Given.Create<Mock<IKeyboardInput>>().ThatPressesKey('3'); 

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
        _matchingType.Should().Be(CardValueAndSuit);
    }
}