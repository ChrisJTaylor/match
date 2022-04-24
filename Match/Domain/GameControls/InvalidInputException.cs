namespace Match.Domain.GameControls;

public class InvalidInputException: Exception
{
    public InvalidInputException(string message) : base(message)
    {
        
    }
}