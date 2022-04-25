using Match.Domain.Cards;

namespace Match.Domain.GameSetup;

public static class CardCollectionExtensions
{
    public static Card[] Shuffle(this Card[] source)
    {
        var rnd = Utility.GetRandomiser();
        return source.OrderBy(_ => rnd.Next()).ToArray();
    }
}