using System;
using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
using Match.Domain.GameSetup;
using NUnit.Framework;

namespace Match.Tests.GameSetup;

public class WhenBuildingPlayers
{
    private Player[] _players = Array.Empty<Player>();

    [OneTimeSetUp]
    public void SetUp()
    {
        var playerBuilder = new PlayerBuilder();
        _players = playerBuilder.BuildPlayers();
    }

    [Test]
    public void ItShouldHaveExpectedNumberOfPlayers()
    {
        _players.Should().HaveCount(2);
    }

    [Test]
    public void PlayersShouldHaveExpectedNames()
    {
        _players.Should().Contain(player => player.Name == "Jack");
        _players.Should().Contain(player => player.Name == "Jill");
    }

    [Test]
    public void PlayersShouldHaveAnEmptyPileOfWinnings()
    {
        _players.Should().OnlyContain(player => player.Winnings == Array.Empty<Card>());
    }
}