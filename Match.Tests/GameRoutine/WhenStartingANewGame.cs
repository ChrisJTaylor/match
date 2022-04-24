using System;
using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
using Match.Domain.GameRoutine;
using Match.Domain.GameSetup;
using NUnit.Framework;
using static Match.Domain.GameRoutine.MatchingCondition;

namespace Match.Tests.GameRoutine;

public class WhenStartingANewGame
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
    public void PlayersShouldHaveAnEmptyPileOfWinnings()
    {
        _game.Players.Should().OnlyContain(player => player.Winnings == Array.Empty<Card>());
    }
}