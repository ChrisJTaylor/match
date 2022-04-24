using FluentAssertions;
using Match.Domain;
using NUnit.Framework;
using static Match.Domain.MatchCondition;

namespace Match.Tests.WhenMatchingCards;

public class BySuit
{
    [TestCaseSource(nameof(MatchingCardTestCases))]
    public void TheCardsShouldMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: Suit).Should().BeTrue();
    }

    [TestCaseSource(nameof(MismatchingCardTestCases))]
    public void TheCardsShouldNotMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: Suit).Should().BeFalse();
    }
    
    static object[] MatchingCardTestCases =
    {
        new object[] { new Card(CardValueEnum.One, CardSuitEnum.Clubs), new Card(CardValueEnum.Two, CardSuitEnum.Clubs) },
        new object[] { new Card(CardValueEnum.Two, CardSuitEnum.Diamonds), new Card(CardValueEnum.Three, CardSuitEnum.Diamonds) },
        new object[] { new Card(CardValueEnum.Three, CardSuitEnum.Diamonds), new Card(CardValueEnum.One, CardSuitEnum.Diamonds) }
    };
    
    static object[] MismatchingCardTestCases =
    {
        new object[] { new Card(CardValueEnum.One, CardSuitEnum.Clubs), new Card(CardValueEnum.One, CardSuitEnum.Diamonds) },
        new object[] { new Card(CardValueEnum.Two, CardSuitEnum.Clubs), new Card(CardValueEnum.Three, CardSuitEnum.Diamonds) },
        new object[] { new Card(CardValueEnum.Three, CardSuitEnum.Diamonds), new Card(CardValueEnum.Three, CardSuitEnum.Clubs) }
    };
}