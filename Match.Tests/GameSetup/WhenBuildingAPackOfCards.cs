using FluentAssertions;
using Match.Domain;
using Match.Domain.Cards;
using NUnit.Framework;

namespace Match.Tests.GameSetup;

public class WhenBuildingAPackOfCards
{
    [Test]
    public void ItShouldContainTheExpectedNumberOfCards()
    {
        Pack.Cards.Should().HaveCount(6);
    }

    [Test]
    public void ItShouldHaveTheExpectedSuits()
    {
        var expectedSuits = new[]
        {
            CardSuits.Clubs,
            CardSuits.Diamonds
        };

        Pack.Suits.Should().BeEquivalentTo(expectedSuits);
    }

    [Test]
    public void ItShouldHaveTheExpectedValues()
    {
        var expectedValues = new[]
        {
            CardValues.One,
            CardValues.Two,
            CardValues.Three
        };

        Pack.Values.Should().BeEquivalentTo(expectedValues);
    }
}