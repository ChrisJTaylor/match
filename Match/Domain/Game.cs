using Match.Domain.GameRoutine;
using Match.Domain.GameSetup;

namespace Match.Domain;
public class Game
{
    private readonly IGameState _gameState;
    private readonly GameCycle _gameCycle;
    private readonly Adjudicator _adjudicator;

    public Game(IGameState gameState, GameCycle gameCycle, Adjudicator adjudicator)
    {
        _gameState = gameState;
        _gameCycle = gameCycle;
        _adjudicator = adjudicator;
    }
    
    public void PlayNewGameWithOptions(GameOptions selectedOptions)
    {
        _gameState.InitialiseStateWithOptions(selectedOptions);
        
        while (GameCanContinue())
        {
            _gameCycle.PlayRound();
        }
        
        _adjudicator.DeclareTheResult();
    }

    private bool GameCanContinue()
    {
        return _gameState.Deck.Count > 0;
    }
}