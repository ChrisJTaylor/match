using Match.Domain.Cards;

namespace Match.Domain;

public class Player
{
    public Player(string name)
    {
        Name = name;
        Winnings = new List<Card>();
    }
    public string Name { get; }
    public List<Card> Winnings { get; }
}