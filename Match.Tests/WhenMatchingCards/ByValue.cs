using FluentAssertions;
using Match.Domain;
using NUnit.Framework;
using static Match.Domain.MatchingTypeEnum;

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
        new object[] { new Card(CardValueEnum.One, CardSuiteEnum.Clubs), new Card(CardValueEnum.One, CardSuiteEnum.Diamonds) },
        new object[] { new Card(CardValueEnum.Two, CardSuiteEnum.Clubs), new Card(CardValueEnum.Two, CardSuiteEnum.Diamonds) },
        new object[] { new Card(CardValueEnum.Three, CardSuiteEnum.Diamonds), new Card(CardValueEnum.Three, CardSuiteEnum.Clubs) }
    };
    
    static object[] MismatchingCardTestCases =
    {
        new object[] { new Card(CardValueEnum.One, CardSuiteEnum.Clubs), new Card(CardValueEnum.Three, CardSuiteEnum.Diamonds) },
        new object[] { new Card(CardValueEnum.Two, CardSuiteEnum.Clubs), new Card(CardValueEnum.One, CardSuiteEnum.Diamonds) },
        new object[] { new Card(CardValueEnum.Three, CardSuiteEnum.Diamonds), new Card(CardValueEnum.Two, CardSuiteEnum.Clubs) }
    };
}