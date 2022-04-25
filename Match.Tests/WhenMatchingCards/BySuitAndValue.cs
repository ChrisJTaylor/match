using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
using NUnit.Framework;
using static Match.Domain.GameRoutine.MatchingCondition;

namespace Match.Tests.WhenMatchingCards;

public class BySuitAndValue
{
    [TestCaseSource(nameof(MatchingCardTestCases))]
    public void TheCardsShouldMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: CardValueAndSuit).Should().BeTrue();
    }

    [TestCaseSource(nameof(MismatchingCardTestCases))]
    public void TheCardsShouldNotMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: CardValueAndSuit).Should().BeFalse();
    }
    
    static object[] MatchingCardTestCases =
    {
        new object[] { new Card(CardValues.Ace, CardSuits.Clubs), new Card(CardValues.Ace, CardSuits.Clubs) },
        new object[] { new Card(CardValues.Two, CardSuits.Diamonds), new Card(CardValues.Two, CardSuits.Diamonds) },
        new object[] { new Card(CardValues.Three, CardSuits.Diamonds), new Card(CardValues.Three, CardSuits.Diamonds) }
    };
    
    static object[] MismatchingCardTestCases =
    {
        new object[] { new Card(CardValues.Ace, CardSuits.Clubs), new Card(CardValues.Ace, CardSuits.Diamonds) },
        new object[] { new Card(CardValues.Two, CardSuits.Diamonds), new Card(CardValues.Three, CardSuits.Diamonds) },
        new object[] { new Card(CardValues.Three, CardSuits.Diamonds), new Card(CardValues.Three, CardSuits.Clubs) }
    };
}