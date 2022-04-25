using Match.Domain.Cards;
using static System.Linq.Enumerable;

namespace Match.Domain.GameSetup;

public class DeckBuilder : IDeckBuilder
{
    public Card[] BuildDeckUsingNumberOfPacks(int numberOfPacks)
    {
        var deck = new List<Card>();
        foreach (var _ in Range(1, numberOfPacks))
        {
            deck.AddRange(Pack.Cards);
        }

        return deck.ToArray().Shuffle();
    }
}