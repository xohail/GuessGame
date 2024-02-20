namespace GuessGame2;

internal abstract class GuessGameController
{
    private static void Main(string[] args)
    {
        GuessGameService guessGameService = new(new UserInput(new ValidateInput()), new RandomNumberGenerator(),
            new ResultGenerator());
        guessGameService.GuessGameAction();
    }
}