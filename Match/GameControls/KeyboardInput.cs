using System.Diagnostics.CodeAnalysis;

namespace Match.GameControls;

[ExcludeFromCodeCoverage]
public class KeyboardInput : IKeyboardInput
{
    public ConsoleKeyInfo ReceiveInput()
    {
        return Console.ReadKey();
    }
}