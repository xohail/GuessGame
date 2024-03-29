namespace GuessGame2;

public class ValidateInput : IValidateInput
{
    public int ValidateIntAndNotZero(string input)
    {
        var value = int.Parse(input);
        if (value <= 0) throw new Exception("Value should not be zero or less than zero");
        return value;
    }

    public int ValidateBetAmount(string input)
    {
        return ValidateIntAndNotZero(input);
    }

    public int ValidateDifficultyValue(string input)
    {
        var difficultyValue = ValidateIntAndNotZero(input);
        if (!new[] { 1, 2, 3 }.Contains(difficultyValue)) throw new Exception("Difficulty value is not valid.");
        return difficultyValue;
    }

    public int ValidateGuessValue(string input, int[] range)
    {
        var guessValue = ValidateIntAndNotZero(input);
        if (!(guessValue >= range[0] && guessValue <= range[1]))
            throw new Exception($"Guess value is not in range of {range}.");
        return guessValue;
    }
}