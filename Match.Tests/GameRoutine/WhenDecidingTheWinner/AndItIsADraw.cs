using System;
using AutoFixture;
using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
using Match.Domain.GameRoutine;
using Match.Domain.GameSetup;
using Moq;
using NUnit.Framework;
using static Match.Domain.Cards.CardSuits;
using static Match.Domain.Cards.CardValues;
using static Match.Domain.GameRoutine.MatchingCondition;

namespace Match.Tests.GameRoutine.WhenDecidingTheWinner;

public class AndItIsADraw
{
    private string _winner;
    
    [OneTimeSetUp]
    public void WhenBothPlayersHaveTheSameScore()
    {
        var deckBuilder = new Mock<IDeckBuilder>();
        deckBuilder.Setup(builder => 
            builder.BuildDeckUsingNumberOfPacks(1))
            .Returns(Array.Empty<Card>());

        var player1 = new Player("Bill");
        player1.Winnings.Add(new Card(One, Diamonds));
        player1.Winnings.Add(new Card(One, Diamonds));
        
        var player2 = new Player("Ben");
        player2.Winnings.Add(new Card(Three, Clubs));
        player2.Winnings.Add(new Card(Three, Clubs));

        var playerBuilder = new Mock<IPlayerBuilder>();
        playerBuilder.Setup(builder =>
            builder.BuildPlayers())
            .Returns(new[] 
            { 
                player1, player2 
            });
        
        var fixture = new Fixture();
        fixture.Register(() => deckBuilder.Object);
        fixture.Register(() => playerBuilder.Object);
        var game = fixture.Create<Game>();
        
        game.PlayNewGameWithOptions(new GameOptions(1, CardValueAndSuit));

        var adjudicator = fixture.Create<Adjudicator>();

        _winner = adjudicator.DetermineTheWinnerOfTheGame(game);
    }

    [Test]
    public void ItShouldDeclareNoOneIsTheWinner()
    {
        _winner.Should().Be("no one");
    }
}