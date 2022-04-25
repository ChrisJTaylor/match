using Match.Domain.Cards;

namespace Match.Domain.GameSetup;

public class DeckBuilder : IDeckBuilder
{
    public Card[] BuildDeckUsingNumberOfPacks(int numberOfPacks)
    {
        var deck = new List<Card>();
        foreach (var _ in Enumerable.Range(1, numberOfPacks))
        {
            deck.AddRange(Pack.Cards);
        }

        return deck.ToArray();
    }
}