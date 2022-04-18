using Match.Domain;
using SimpleInjector;

namespace Match // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.Options.ResolveUnregisteredConcreteTypes = true;
            container.Register<IKeyboardInput, KeyboardInput>();
            container.RegisterInstance<TextWriter>(Console.Out);

            var playerInput = container.GetInstance<PlayerInput>();

            var numberOfPacks = playerInput.AskPlayerHowManyPacksOfCardsToUse();
            var matchingType = playerInput.AskPlayerWhichMatchingTypeToUse();
        }
    }
}