using static Match.Domain.Cards.CardSuits;
using static Match.Domain.Cards.CardValues;

namespace Match.Domain.Cards;

public static class Pack
{
    static Pack()
    {
        Cards = BuildPackOfCards().ToArray();
    }
    
    public static Card[] Cards { get; }

    public static IEnumerable<CardSuits> Suits => new[]
    {
        Clubs, Diamonds, Spades, Hearts
    };
    public static IEnumerable<CardValues> Values => new[]
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    };

    private static IEnumerable<Card> BuildPackOfCards()
    {
        return from suit in Suits
            from value in Values
            select new Card(value, suit);
    }
}