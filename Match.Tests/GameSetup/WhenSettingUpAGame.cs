using System;
using FluentAssertions;
using Match.Domain;
using Match.Domain.GameRoutine;
using Match.Domain.GameSetup;
using NUnit.Framework;

namespace Match.Tests.GameSetup;

public class WhenSettingUpAGame
{
    private readonly Game _game = new(new DeckBuilder());

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
    
    [TestCase(1, MatchCondition.Suit)]
    [TestCase(2, MatchCondition.CardValue)]
    [TestCase(3, MatchCondition.Suit)]
    [TestCase(4, MatchCondition.CardValue)]
    [TestCase(5, MatchCondition.CardValueAndSuit)]
    [TestCase(6, MatchCondition.Suit)]
    [TestCase(7, MatchCondition.CardValue)]
    [TestCase(8, MatchCondition.Suit)]
    [TestCase(9, MatchCondition.CardValueAndSuit)]
    public void TheSelectedOptionsShouldBeApplied(int numberOfPacks, MatchCondition selectedMatchCondition)
    {
        var options = new GameOptions(numberOfPacks, selectedMatchCondition);
        _game.SetupNewGameWithOptions(options);
        
        var expectedCount = numberOfPacks * Pack.Cards.Length;
        
        _game.Deck.Should().HaveCount(expectedCount);
    }
}