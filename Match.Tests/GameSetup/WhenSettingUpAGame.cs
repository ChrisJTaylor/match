using System;
using System.Linq;
using FluentAssertions;
using Match.Domain;
using Match.GameRoutine;
using NUnit.Framework;

namespace Match.Tests.GameSetup;

public class WhenSettingUpAGame
{
    private Game _game;
    
    [OneTimeSetUp]
    public void WhenInitialisingGame()
    {
        _game = new Game();
    }

    [Test]
    public void ItShouldHaveExpectedNumberOfPlayers()
    {
        _game.Players.Should().HaveCount(2);
    }

    [Test]
    public void PlayersShouldHaveExpectedNames()
    {
        _game.Players.Should().Contain(player => player.Name == "Jack");
        _game.Players.Should().Contain(player => player.Name == "Jill");
    }

    [Test]
    public void PlayersShouldHaveAnEmptyPileOfCards()
    {
        _game.Players.Should().OnlyContain(player => player.Pile == Array.Empty<Card>());
    }
    
    [TestCaseSource(nameof(GameSetupTestCases))]
    public void TheSelectedOptionsShouldBeApplied(int numberOfPacks, MatchCondition selectedMatchCondition)
    {
        var options = new GameOptions(numberOfPacks, selectedMatchCondition);
        _game.SetupNewGameWithOptions(options);
        
        var expectedCount = numberOfPacks * Pack.Cards.Length;
        
        _game.Deck.Should().HaveCount(expectedCount);
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