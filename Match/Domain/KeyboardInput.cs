using System.Diagnostics.CodeAnalysis;

namespace Match.Domain;

[ExcludeFromCodeCoverage]
public class KeyboardInput : IKeyboardInput
{
    public ConsoleKeyInfo ReceiveInput()
    {
        return Console.ReadKey();
    }
}