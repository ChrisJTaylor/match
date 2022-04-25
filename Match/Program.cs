using System.Diagnostics.CodeAnalysis;
using Match.Domain;
using Match.Domain.GameControls;
using Match.Domain.GameRoutine;
using Match.Domain.GameSetup;
using SimpleInjector;

namespace Match;

[ExcludeFromCodeCoverage]
internal class Program
{
    private static readonly Container Container = SetupIoC();
    static void Main(string[] args)
    {
        var game = Container.GetInstance<Game>();
        
        try
        {
            var gameOptions = GetOptionsFromPlayerInput();
            game.PlayNewGameWithOptions(gameOptions);
        }
        catch (InvalidInputException e)
        {
            Console.WriteLine();
            Console.WriteLine(e.Message);
        }
    }

    private static GameOptions GetOptionsFromPlayerInput()
    {
        var playerInput = Container.GetInstance<PlayerInput>();
        
        var numberOfPacks = playerInput.AskPlayerHowManyPacksOfCardsToUse(); 
        Console.WriteLine();
            
        var matchCondition = playerInput.AskPlayerWhichMatchingConditionToUse();
        Console.WriteLine();

        return new GameOptions(numberOfPacks, matchCondition);
    }

    private static Container SetupIoC()
    {
        var container = new Container();
        container.Options.ResolveUnregisteredConcreteTypes = true;
        container.Register<IKeyboardInput, KeyboardInput>();
        container.RegisterInstance(Console.Out);
        container.Register<IDeckBuilder, DeckBuilder>(Lifestyle.Singleton);
        container.Register<IPlayerBuilder, PlayerBuilder>(Lifestyle.Singleton);
        container.Register<IGameState, GameState>(Lifestyle.Singleton);
        return container;
    }
}