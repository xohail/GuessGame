namespace GuessGame2;

public interface IResultGenerator
{
    void GetResultAndDisplay(int betAmount, int guessValue, int randomNumber, int difficultyValue);
}