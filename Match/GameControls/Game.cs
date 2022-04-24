using Match.Domain;

namespace Match.GameControls;
public class Game
{
    public Game(GameOptions withOptions)
    {
        Deck = BuildDeckWith(numberOfPacks: withOptions.NumberOfPacksToUse);
    }

    private Card[] BuildDeckWith(int numberOfPacks)
    {
        var pack = new Cards().Pack;
        var deck = new List<Card>(); 
        for (var iteration = 1; iteration <= numberOfPacks; iteration++)
        {
            deck.AddRange(pack);
        }

        return deck.ToArray();
    }

    public Card[] Deck { get; }
}