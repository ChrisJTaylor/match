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
        Clubs, Diamonds
    };
    public static IEnumerable<CardValues> Values => new[]
    {
        One, Two, Three
    };

    private static IEnumerable<Card> BuildPackOfCards()
    {
        return from suit in Suits
            from value in Values
            select new Card(value, suit);
    }
}