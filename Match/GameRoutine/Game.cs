using Match.Domain;

namespace Match.GameRoutine;
public class Game
{
    public Game(GameOptions withOptions)
    {
        Deck = BuildDeckWith(numberOfPacks: withOptions.NumberOfPacksToUse);
    }

    private Card[] BuildDeckWith(int numberOfPacks)
    {
        var deck = new List<Card>(); 
        for (var iteration = 1; iteration <= numberOfPacks; iteration++)
        {
            deck.AddRange(Pack.Cards);
        }

        return deck.ToArray();
    }

    public Card[] Deck { get; }
}