namespace Match.Domain;

public class Pack
{
    static Pack()
    {
        Cards = BuildPackOfCards().ToArray();
    }
    
    public static Card[] Cards { get; }

    public static IEnumerable<CardSuitEnum> Suits => new[] { CardSuitEnum.Clubs, CardSuitEnum.Diamonds };
    public static IEnumerable<CardValueEnum> Values => new[] { CardValueEnum.One, CardValueEnum.Two, CardValueEnum.Three };

    private static IEnumerable<Card> BuildPackOfCards()
    {
        return from suit in Suits
            from value in Values
            select new Card(value, suit);
    }
}