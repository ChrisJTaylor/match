using Match.Domain;

namespace Match.GameRoutine;

public class DeckBuilder : IDeckBuilder
{
    public Card[] BuildDeckUsingNumberOfPacks(int numberOfPacks)
    {
        var deck = new List<Card>(); 
        for (var iteration = 1; iteration <= numberOfPacks; iteration++)
        {
            deck.AddRange(Pack.Cards);
        }

        return deck.ToArray();
    }
}