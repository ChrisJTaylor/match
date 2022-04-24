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

        var playerBuilder = new Mock<IPlayerBuilder>();
        playerBuilder.Setup(builder => builder.BuildPlayers()).Returns(new[]
        {
            new Player("Bill"),
            new Player("Ben"),
        });
        
        _game = new Game(deckBuilder.Object, playerBuilder.Object);
        
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