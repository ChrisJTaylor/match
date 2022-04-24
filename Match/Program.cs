using System.Diagnostics.CodeAnalysis;
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
            
            game.SetupNewGameWithOptions(gameOptions);
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
            
        var matchCondition = playerInput.AskPlayerWhichMatchingTypeToUse();
        Console.WriteLine();

        var gameOptions = new GameOptions(numberOfPacks, matchCondition);
        return gameOptions;
    }

    private static Container SetupIoC()
    {
        var container = new Container();
        container.Options.ResolveUnregisteredConcreteTypes = true;
        container.Register<IKeyboardInput, KeyboardInput>();
        container.RegisterInstance<TextWriter>(Console.Out);
        container.Register<IDeckBuilder, DeckBuilder>();
        return container;
    }
}