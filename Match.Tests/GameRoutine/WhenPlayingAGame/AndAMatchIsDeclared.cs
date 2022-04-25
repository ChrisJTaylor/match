using System.Linq;
using AutoFixture;
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
        var selectedOptions = new GameOptions(1, Suit);
        
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
            builder.BuildDeckUsingNumberOfPacks(selectedOptions.NumberOfPacksToUse))
            .Returns(_cardCollection);

        var fixture = new Fixture();
        fixture.Register(() => deckBuilder.Object);
        fixture.Register<IPlayerBuilder>(() => new PlayerBuilder());
        _game = fixture.Create<Game>();

        _game.PlayNewGameWithOptions(selectedOptions);
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