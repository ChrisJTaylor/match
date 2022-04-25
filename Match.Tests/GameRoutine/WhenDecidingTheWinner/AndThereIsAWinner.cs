using System;
using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
using Match.Domain.GameRoutine;
using Match.Domain.GameSetup;
using Moq;
using NUnit.Framework;
using static Match.Domain.Cards.CardSuits;
using static Match.Domain.Cards.CardValues;

namespace Match.Tests.GameRoutine.WhenDecidingTheWinner;

public class AndThereIsAWinner
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

        var playerBuilder = new Mock<IPlayerBuilder>();
        playerBuilder.Setup(builder =>
            builder.BuildPlayers())
            .Returns(new[] 
            { 
                player1, player2 
            });
        
        var game = new Game(deckBuilder.Object, playerBuilder.Object);
        game.StartNewGameWithOptions(new GameOptions(1, MatchingCondition.CardValueAndSuit));

        var adjudicator = new Adjudicator();

        _winner = adjudicator.DetermineTheWinnerOfTheGame(game);
    }

    [Test]
    public void ItShouldDeclareTheExpectedWinner()
    {
        _winner.Should().Be("Bill");
    }
}