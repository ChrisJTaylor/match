using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
using Match.Domain.GameSetup;
using Moq;
using NUnit.Framework;
using static Match.Domain.Cards.CardSuits;
using static Match.Domain.Cards.CardValues;
using static Match.Domain.GameRoutine.MatchingCondition;

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
            new Card(One, Clubs),
            new Card(Three, Diamonds)
        };
        
        var deckBuilder = new Mock<IDeckBuilder>();
        deckBuilder.Setup(builder => 
            builder.BuildDeckUsingNumberOfPacks(1))
            .Returns(_cardCollection);

        _game = new Game(deckBuilder.Object, new PlayerBuilder());
        
        _game.PlayNewGameWithOptions(new GameOptions(1, CardValueAndSuit));
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