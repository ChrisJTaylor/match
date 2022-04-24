namespace Match.Domain;

public class Cards
{
    static Cards()
    {
        Pack = BuildPackOfCards().ToArray();
    }
    
    public static Card[] Pack { get; }

    public static IEnumerable<CardSuitEnum> Suits => new[] { CardSuitEnum.Clubs, CardSuitEnum.Diamonds };
    public static IEnumerable<CardValueEnum> Values => new[] { CardValueEnum.One, CardValueEnum.Two, CardValueEnum.Three };

    private static IEnumerable<Card> BuildPackOfCards()
    {
        foreach (var suit in Suits)
        {
            foreach (var value in Values)
            {
                yield return new Card(value, suit);
            } 
        }
    }
}