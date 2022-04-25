using System;
using System.IO;
using System.Text;
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
    private readonly StringBuilder _consoleOut = new();

    [OneTimeSetUp]
    public void WhenBothPlayersHaveTheSameScore()
    {
        var deckBuilder = new Mock<IDeckBuilder>();
        deckBuilder.Setup(builder => 
            builder.BuildDeckUsingNumberOfPacks(1))
            .Returns(Array.Empty<Card>());

        var player1 = new Player("Bill");
        player1.Winnings.Add(new Card(Ace, Diamonds));
        player1.Winnings.Add(new Card(Ace, Diamonds));
        
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
        fixture.Register<TextWriter>(() => new StringWriter(_consoleOut));
        var gameState = fixture.Create<GameState>();
        fixture.Register<IGameState>(() => gameState);
        
        var game = fixture.Create<Game>();
        game.PlayNewGameWithOptions(new GameOptions(1, CardValueAndSuit));

        var adjudicator = fixture.Create<Adjudicator>();
        adjudicator.DeclareTheResult();
    }

    [Test]
    public void ItShouldDeclareTheGameADraw()
    {
        _consoleOut.ToString().Should().Contain($"The game is a draw!");
    }
}