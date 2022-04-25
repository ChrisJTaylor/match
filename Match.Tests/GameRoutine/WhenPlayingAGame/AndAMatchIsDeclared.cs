using System.Linq;
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

public class AndAMatchIsDeclared
{
    private Game _game;
    private Card[] _cardCollection;
    
    [OneTimeSetUp]
    public void WhenAGameHasAMatchingPair()
    {
        _cardCollection = new[]
        {
            new Card(One, Diamonds),
            new Card(Three, Clubs),
            new Card(Two, Diamonds),
            new Card(Three, Diamonds),
            new Card(One, Clubs)
        };
        
        var deckBuilder = new Mock<IDeckBuilder>();
        deckBuilder.Setup(builder => 
            builder.BuildDeckUsingNumberOfPacks(It.IsAny<int>()))
            .Returns(_cardCollection);

        _game = new Game(deckBuilder.Object, new PlayerBuilder());
        
        _game.PlayNewGameWithOptions(new GameOptions(1, Suit));
    }

    [Test]
    public void ItShouldHaveNoMoreCardsInTheDeck()
    {
        _game.Deck.Should().BeEmpty();
    }
    
    [Test]
    public void TheDeclaringPlayerShouldWinTheAccruedCardsInThePile()
    {
        var declaringPlayer = _game.Players.First(player => player.Winnings.Count > 0);
        declaringPlayer.Winnings.Should().ContainInOrder(new[]
        {
            new Card(Two, Diamonds),
            new Card(Three, Diamonds),
            new Card(One, Clubs)
        });
    }
}