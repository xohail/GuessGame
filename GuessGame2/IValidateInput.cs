namespace GuessGame2;

public interface IValidateInput
{
    int ValidateIntAndNotZero(string input);
    int ValidateBetAmount(string input);
    int ValidateDifficultyValue(string input);
    int ValidateGuessValue(string input, int[] range);
}