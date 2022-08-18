namespace Match.Tests.WhenMatchingCards;

public class BySuit
{
    [TestCaseSource(nameof(_matchingCardTestCases))]
    public void TheCardsShouldMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: Suit).Should().BeTrue();
    }

    [TestCaseSource(nameof(_mismatchingCardTestCases))]
    public void TheCardsShouldNotMatch(Card firstCard, Card secondCard)
    {
        firstCard.IsAMatchFor(secondCard, matchingBy: Suit).Should().BeFalse();
    }
    
    static object[] _matchingCardTestCases =
    {
        new object[] { new Card(Ace, Clubs), new Card(Two, Clubs) },
        new object[] { new Card(Two, Diamonds), new Card(Three, Diamonds) },
        new object[] { new Card(Three, Diamonds), new Card(Ace, Diamonds) }
    };
    
    static object[] _mismatchingCardTestCases =
    {
        new object[] { new Card(Ace, Clubs), new Card(Ace, Diamonds) },
        new object[] { new Card(Two, Clubs), new Card(Three, Diamonds) },
        new object[] { new Card(Three, Diamonds), new Card(Three, Clubs) }
    };
}