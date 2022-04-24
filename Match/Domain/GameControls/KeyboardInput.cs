using System.Diagnostics.CodeAnalysis;

namespace Match.Domain.GameControls;

[ExcludeFromCodeCoverage]
public class KeyboardInput : IKeyboardInput
{
    public ConsoleKeyInfo ReceiveInput()
    {
        return Console.ReadKey();
    }
}