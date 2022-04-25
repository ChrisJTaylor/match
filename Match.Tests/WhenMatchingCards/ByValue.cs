using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
using NUnit.Framework;
using static Match.Domain.Cards.CardSuits;
using static Match.Domain.Cards.CardValues;
using static Match.Domain.GameRoutine.MatchingCondition;

namespace Match.Tests.WhenMatchingCards;

public class ByValue
{
    [TestCaseSource(nameof(_matchingCardTestCases))]
    public void TheCardsShouldMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: CardValue).Should().BeTrue();
    }

    [TestCaseSource(nameof(_mismatchingCardTestCases))]
    public void TheCardsShouldNotMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: CardValue).Should().BeFalse();
    }
    
    static object[] _matchingCardTestCases =
    {
        new object[] { new Card(Ace, Clubs), new Card(Ace, Diamonds) },
        new object[] { new Card(Two, Clubs), new Card(Two, Diamonds) },
        new object[] { new Card(Three, Diamonds), new Card(Three, Clubs) }
    };
    
    static object[] _mismatchingCardTestCases =
    {
        new object[] { new Card(Ace, Clubs), new Card(Three, Diamonds) },
        new object[] { new Card(Two, Clubs), new Card(Ace, Diamonds) },
        new object[] { new Card(Three, Diamonds), new Card(Two, Clubs) }
    };
}