namespace GuessGame2;

public class ValidateInput
{
    private int ValidateIntAndNotZero(String input)
    {
        int value = int.Parse(input);
        if (value == 0)
        {
            throw new Exception("Betting amount should not be 0");
        }
        return value;
    }

    public int ValidateBetAmount(String input)
    {
        return ValidateIntAndNotZero(input);
    }
    
    public int ValidateDifficultyValue(String input)
    {
        int difficultyValue = ValidateIntAndNotZero(input);
        if (!new[] { 1, 2, 3 }.Contains(difficultyValue))
        {
            throw new Exception("Difficulty value is not valid.");
        }
        return difficultyValue;
    }
    
    public int ValidateGuessValue(String input, int[] range)
    {
        int guessValue = ValidateIntAndNotZero(input);
        if (!(guessValue >= range[0] && guessValue <= range[1]))
        {
            throw new Exception($"Guess value is not in range of {range}.");
        }
        return guessValue;
    }
}