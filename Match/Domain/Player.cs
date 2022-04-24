using Match.Domain.Cards;

namespace Match.Domain;

public class Player
{
    public Player(string name)
    {
        Name = name;
        Winnings = Array.Empty<Card>();
    }
    public string Name { get; }
    public IList<Card> Winnings { get; }
}