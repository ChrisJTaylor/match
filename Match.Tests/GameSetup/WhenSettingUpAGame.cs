using FluentAssertions;
using Match.Domain;
using Match.GameRoutine;
using NUnit.Framework;

namespace Match.Tests.GameSetup;

public class WhenSettingUpAGame
{
    [TestCaseSource(nameof(GameSetupTestCases))]
    public void TheSelectedOptionsShouldBeApplied(int numberOfPacks, MatchCondition selectedMatchCondition)
    {
        var game = new Game();
        
        var options = new GameOptions(numberOfPacks, selectedMatchCondition);
        game.SetupNewGameWithOptions(options);
        
        var expectedCount = numberOfPacks * Pack.Cards.Length;
        
        game.Deck.Should().HaveCount(expectedCount);
    }
    
    static object[] GameSetupTestCases =
    {
        new object[] { 1, MatchCondition.Suit },
        new object[] { 2, MatchCondition.CardValue },
        new object[] { 3, MatchCondition.CardValueAndSuit },
        new object[] { 5, MatchCondition.CardValue },
        new object[] { 9, MatchCondition.Suit }
    };
}