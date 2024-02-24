using Castle.DynamicProxy;

namespace GuessGame2;

public class UserInput : IUserInput
{
    private readonly DisplayInformation _displayInformation;
    private readonly IValidateInput _validateInput;

    public UserInput(IValidateInput validateInput)
    {
        var generator = new ProxyGenerator();
        var interceptor = new MethodInterceptor();
        _displayInformation = generator.CreateClassProxy<DisplayInformation>(interceptor);
        
        _validateInput = validateInput;
    }

    public int GetBetAmount()
    {
        _displayInformation.DisplayMessage(
            "\u001b[1mWelcome to the Guess Game!!!\u001b[0m\nPlease enter the money you want to bet: ");
        return _validateInput.ValidateBetAmount(Console.ReadLine()!);
    }

    public int GetDifficultyLevel()
    {
        _displayInformation.DisplayMessage("\u001b[1mChoose the difficulty level\u001b[0m",
            "1) 1 to 5   Easy",
            "2) 1 to 10  Medium",
            "3) 1 to 20  Hard"
        );
        return _validateInput.ValidateDifficultyValue(Console.ReadLine()!);
    }

    public int GetUserGuess(int[] range)
    {
        _displayInformation.DisplayMessage($"\u001b[1mEnter your guess from {range[0]} to {range[1]} \u001b[0m");
        return _validateInput.ValidateGuessValue(Console.ReadLine()!, range);
    }
}