namespace Match.Tests.WhenMatchingCards;

public class NoMatchingConditionSelected
{
    [TestCaseSource(nameof(_mismatchingCardTestCases))]
    public void TheCardsShouldNotMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: MatchingCondition.None).Should().BeFalse();
    }
    
    static object[] _mismatchingCardTestCases =
    {
        new object[] { new Card(Ace, Clubs), new Card(Ace, Diamonds) },
        new object[] { new Card(Two, Clubs), new Card(Two, Clubs) },
        new object[] { new Card(Three, Diamonds), new Card(Two, Diamonds) }
    };
}