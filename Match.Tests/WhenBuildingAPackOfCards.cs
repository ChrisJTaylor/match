using FluentAssertions;
using Match.Domain;
using NUnit.Framework;

namespace Match.Tests;

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
            CardSuitEnum.Clubs,
            CardSuitEnum.Diamonds
        };

        Pack.Suits.Should().BeEquivalentTo(expectedSuits);
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

        Pack.Values.Should().BeEquivalentTo(expectedValues);
    }
}