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

namespace Match.Tests.GameRoutine.WhenPlayingAGame;

public class AndNoMoreCardsCanBeDrawn
{
    private IGameState _gameState;
    private Card[] _cardCollection;
    
    [OneTimeSetUp]
    public void WhenAGameIsComingToAClose()
    {
        var selectedOptions = new GameOptions(1, CardValueAndSuit);
        
        _cardCollection = new[]
        {
            new Card(Ace, Clubs),
            new Card(Three, Diamonds)
        };
        
        var deckBuilder = new Mock<IDeckBuilder>();
        deckBuilder.Setup(builder => 
            builder.BuildDeckUsingNumberOfPacks(selectedOptions.NumberOfPacksToUse))
            .Returns(_cardCollection);

        var fixture = new Fixture();
        fixture.Register(() => deckBuilder.Object);
        fixture.Register<IPlayerBuilder>(() => new PlayerBuilder());
        fixture.Register(() => Console.Out);
        _gameState = fixture.Create<GameState>();
        fixture.Register(() => _gameState);
        var game = fixture.Create<Game>(); 
        
        game.PlayNewGameWithOptions(selectedOptions);
    }

    [Test]
    public void ItShouldHaveNoMoreCardsInTheDeck()
    {
        _gameState.Deck.Should().BeEmpty();
    }
    
    [Test]
    public void ItShouldPopulateThePileFromCardsTakenFromTheDeck()
    {
        _gameState.Pile.Should().ContainInOrder(_cardCollection);
    }
}