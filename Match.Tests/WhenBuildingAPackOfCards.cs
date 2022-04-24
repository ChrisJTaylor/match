using FluentAssertions;
using Match.Domain;
using NUnit.Framework;

namespace Match.Tests;

public class WhenBuildingAPackOfCards
{
    [Test]
    public void ItShouldContainTheExpectedNumberOfCards()
    {
        Cards.Pack.Should().HaveCount(6);
    }

    [Test]
    public void ItShouldHaveTheExpectedSuits()
    {
        var expectedSuits = new[]
        {
            CardSuitEnum.Clubs,
            CardSuitEnum.Diamonds
        };

        Cards.Suits.Should().BeEquivalentTo(expectedSuits);
    }

    [Test]
    public void ItShouldHaveTheExpectedValues()
    {
        var expectedValues = new[]
        {
            CardValueEnum.One,
            CardValueEnum.Two,
            CardValueEnum.Three
        };

        Cards.Values.Should().BeEquivalentTo( expectedValues);
    }
}