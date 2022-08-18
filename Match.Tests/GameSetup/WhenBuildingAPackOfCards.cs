namespace Match.Tests.GameSetup;

public class WhenBuildingAPackOfCards
{
    [Test]
    public void ItShouldContainTheExpectedNumberOfCards()
    {
        Pack.Cards.Should().HaveCount(52);
    }

    [Test]
    public void ItShouldHaveTheExpectedSuits()
    {
        var expectedSuits = new[]
        {
            Clubs, Diamonds, Hearts, Spades
        };

        Pack.Suits.Should().BeEquivalentTo(expectedSuits);
    }

    [Test]
    public void ItShouldHaveTheExpectedValues()
    {
        var expectedValues = new[]
        {
            Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
        };

        Pack.Values.Should().BeEquivalentTo(expectedValues);
    }
}