using System.Diagnostics.CodeAnalysis;
using Match.Domain;
using Match.GameControls;
using Match.GameRoutine;
using SimpleInjector;

namespace Match;

[ExcludeFromCodeCoverage]
internal class Program
{
    static void Main(string[] args)
    {
        var container = SetupIoC();
            
        var playerInput = container.GetInstance<PlayerInput>();

        try
        {
            var numberOfPacks = playerInput.AskPlayerHowManyPacksOfCardsToUse();
            Console.WriteLine();
            
            var matchCondition = playerInput.AskPlayerWhichMatchingTypeToUse();
            Console.WriteLine();

            var gameOptions = new GameOptions(numberOfPacks, matchCondition);
        }
        catch (InvalidInputException e)
        {
            Console.WriteLine();
            Console.WriteLine(e.Message);
        }
    }

    private static Container SetupIoC()
    {
        var container = new Container();
        container.Options.ResolveUnregisteredConcreteTypes = true;
        container.Register<IKeyboardInput, KeyboardInput>();
        container.RegisterInstance<TextWriter>(Console.Out);
        return container;
    }
}