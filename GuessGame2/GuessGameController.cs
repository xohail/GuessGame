namespace GuessGame2;

abstract class GuessGameController
{
    static void Main(string[] args)
    {
        GuessGameService guessGameService = new(new UserInput(new ValidateInput()), new RandomNumberGenerator(), new ResultGenerator());
        guessGameService.GuessGameAction();
    }
}