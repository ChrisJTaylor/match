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
        
        var expectedCount = numberOfPacks * Pack.Cards.Length;
        deck.Should().HaveCount(expectedCount);
    }
}