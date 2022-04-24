namespace Match.Domain;

public class Pack
{
    static Pack()
    {
        Cards = BuildPackOfCards().ToArray();
    }
    
    public static Card[] Cards { get; }

    public static IEnumerable<CardSuits> Suits => new[] { CardSuits.Clubs, CardSuits.Diamonds };
    public static IEnumerable<CardValues> Values => new[] { CardValues.One, CardValues.Two, CardValues.Three };

    private static IEnumerable<Card> BuildPackOfCards()
    {
        return from suit in Suits
            from value in Values
            select new Card(value, suit);
    }
}