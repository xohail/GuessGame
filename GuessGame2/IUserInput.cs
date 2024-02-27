namespace GuessGame2;

public interface IUserInput
{
    int GetBetAmount();
    int GetDifficultyLevel();
    int GetUserGuess(int[] range);
}