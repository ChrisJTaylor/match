using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace Match.Tests.GameSetup;

using TestHelpers;

public class WhenBuildingADeckOfCards
{
    [TestCase(1)] 
    [TestCase(2)] 
    [TestCase(3)] 
    [TestCase(4)] 
    [TestCase(5)] 
    [TestCase(6)] 
    [TestCase(7)] 
    [TestCase(8)] 
    [TestCase(9)] 
    public void ItShouldBuildTheExpectedDeckUsingTheSpecifiedNumberOfPacks(int numberOfPacks)
    {
        var deck = Given.Create<DeckBuilder>().BuildDeckUsingNumberOfPacks(numberOfPacks);

        var totalCards = new List<Card>();
        foreach (var _ in Range(1, numberOfPacks))
        {
            totalCards.AddRange(Pack.Cards);
        }
        
        deck.Should().HaveCount(totalCards.Count);
        deck.Should().NotContainInOrder(totalCards);
    }
}