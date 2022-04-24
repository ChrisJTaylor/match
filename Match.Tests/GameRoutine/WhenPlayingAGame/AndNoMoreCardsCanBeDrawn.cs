using System.Linq;
using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
using Match.Domain.GameRoutine;
using Match.Domain.GameSetup;
using Moq;
using NUnit.Framework;

namespace Match.Tests.GameRoutine.WhenPlayingAGame;

public class AndNoMoreCardsCanBeDrawn
{
    private Game _game;
    private Card[] _cardCollection;
    
    [OneTimeSetUp]
    public void WhenAGameIsComingToAClose()
    {
        _cardCollection = new[]
        {
            new Card(CardValues.One, CardSuits.Clubs),
            new Card(CardValues.Three, CardSuits.Diamonds)
        };
        
        var deckBuilder = new Mock<IDeckBuilder>();
        deckBuilder.Setup(builder => 
            builder.BuildDeckUsingNumberOfPacks(1))
            .Returns(_cardCollection);
        _game = new Game(deckBuilder.Object);
        
        _game.StartNewGameWithOptions(new GameOptions(1, MatchingCondition.CardValueAndSuit));
    }

    [Test]
    public void ItShouldHaveNoMoreCardsInTheDeck()
    {
        _game.Deck.Should().BeEmpty();
    }
    
    [Test]
    public void ItShouldPopulateThePileFromCardsTakenFromTheDeck()
    {
        _game.Pile.Should().ContainInOrder(_cardCollection);
    }
}