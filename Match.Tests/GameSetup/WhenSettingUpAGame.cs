using System;
using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
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
    
    [TestCase(1, MatchingCondition.Suit)]
    [TestCase(2, MatchingCondition.CardValue)]
    [TestCase(3, MatchingCondition.Suit)]
    [TestCase(4, MatchingCondition.CardValue)]
    [TestCase(5, MatchingCondition.CardValueAndSuit)]
    [TestCase(6, MatchingCondition.Suit)]
    [TestCase(7, MatchingCondition.CardValue)]
    [TestCase(8, MatchingCondition.Suit)]
    [TestCase(9, MatchingCondition.CardValueAndSuit)]
    public void TheSelectedOptionsShouldBeApplied(int numberOfPacks, MatchingCondition selectedMatchingCondition)
    {
        var options = new GameOptions(numberOfPacks, selectedMatchingCondition);
        _game.SetupNewGameWithOptions(options);
        
        var expectedCount = numberOfPacks * Pack.Cards.Length;
        
        _game.Deck.Should().HaveCount(expectedCount);
    }
}