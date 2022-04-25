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
        var adjudicator = Container.GetInstance<Adjudicator>();
        
        try
        {
            var gameOptions = GetOptionsFromPlayerInput();
            
            game.PlayNewGameWithOptions(gameOptions);

            var winner = adjudicator.DetermineTheWinnerOfTheGame(game);
            
            Console.WriteLine();
            Console.WriteLine($"The winner is {winner}");
            Console.WriteLine();
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
        container.RegisterInstance<TextWriter>(Console.Out);
        container.Register<IDeckBuilder, DeckBuilder>();
        container.Register<IPlayerBuilder, PlayerBuilder>();
        return container;
    }
}