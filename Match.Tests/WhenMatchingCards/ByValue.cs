using FluentAssertions;
using Match.Domain;
using NUnit.Framework;
using static Match.Domain.MatchingCondition;

namespace Match.Tests.WhenMatchingCards;

public class ByValue
{
    [TestCaseSource(nameof(MatchingCardTestCases))]
    public void TheCardsShouldMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: CardValue).Should().BeTrue();
    }

    [TestCaseSource(nameof(MismatchingCardTestCases))]
    public void TheCardsShouldNotMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: CardValue).Should().BeFalse();
    }
    
    static object[] MatchingCardTestCases =
    {
        new object[] { new Card(CardValues.One, CardSuits.Clubs), new Card(CardValues.One, CardSuits.Diamonds) },
        new object[] { new Card(CardValues.Two, CardSuits.Clubs), new Card(CardValues.Two, CardSuits.Diamonds) },
        new object[] { new Card(CardValues.Three, CardSuits.Diamonds), new Card(CardValues.Three, CardSuits.Clubs) }
    };
    
    static object[] MismatchingCardTestCases =
    {
        new object[] { new Card(CardValues.One, CardSuits.Clubs), new Card(CardValues.Three, CardSuits.Diamonds) },
        new object[] { new Card(CardValues.Two, CardSuits.Clubs), new Card(CardValues.One, CardSuits.Diamonds) },
        new object[] { new Card(CardValues.Three, CardSuits.Diamonds), new Card(CardValues.Two, CardSuits.Clubs) }
    };
}