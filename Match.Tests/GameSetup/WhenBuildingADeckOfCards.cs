using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
using Match.Domain.GameSetup;
using NUnit.Framework;

namespace Match.Tests.GameSetup;

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
        var deckBuilder = new DeckBuilder();
        var deck = deckBuilder.BuildDeckUsingNumberOfPacks(numberOfPacks);

        var totalCards = new List<Card>();
        foreach (var _ in Enumerable.Range(1, numberOfPacks))
        {
            totalCards.AddRange(Pack.Cards);
        }
        
        deck.Should().HaveCount(totalCards.Count);
        deck.Should().NotContainInOrder(totalCards);
    }
}