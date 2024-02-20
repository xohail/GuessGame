using System.Text.RegularExpressions;

namespace GuessGame2;

public class GuessGameService
{
    private readonly UserInput _userInput;
    private readonly RandomNumberGenerator _randomNumberGenerator;
    private readonly ResultGenerator _resultGenerator;

    private readonly Dictionary<int, string?> _difficultyRanges = new()
    {
        { 1, "1 to 5" },
        { 2, "1 to 10" },
        { 3, "1 to 20" }
    };

    public GuessGameService(UserInput userInput, RandomNumberGenerator randomNumberGenerator, ResultGenerator resultGenerator)
    {
        _userInput = new UserInput(new ValidateInput());
        _randomNumberGenerator = new RandomNumberGenerator();
        _resultGenerator = new ResultGenerator();
    }

    public void GuessGameAction()
    {
        try
        {
            var betAmount = _userInput.GetBetAmount();
            int difficultyLevel = _userInput.GetDifficultyLevel();
            
            int[] rangeToPickFrom = GetRangeInArray(_difficultyRanges.GetValueOrDefault(difficultyLevel));
            
            int guessValue = _userInput.GetUserGuess(rangeToPickFrom);
            int randomNumber = _randomNumberGenerator.GetRandomNumber(rangeToPickFrom);

            _resultGenerator.GetResultAndDisplay(betAmount, guessValue, randomNumber, difficultyLevel);

        } catch (Exception ex) {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    private int[] GetRangeInArray(String range)
    {
        Match match = Regex.Match(range, @"(\d+)\s*to\s*(\d+)");
        return new[] { int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value) };
    }
}