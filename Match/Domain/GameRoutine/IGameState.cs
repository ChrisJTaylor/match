using Match.Domain.Cards;
using Match.Domain.GameSetup;

namespace Match.Domain.GameRoutine;

public interface IGameState
{
    Stack<Card> Deck { get; }
    Stack<Card> Pile { get; }
    Player[] Players { get; }
    void InitialiseStateWithOptions(GameOptions selectedOptions);
}