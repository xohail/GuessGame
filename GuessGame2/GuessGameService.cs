using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GuessGame2;

public class GuessGameService
{
    private const string RangeEasy = "1 to 5";
    private const string RangeMedium = "1 to 10";
    private const string RangeHard = "1 to 20";

    private readonly IUserInput _userInput;
    private readonly IRandomNumberGenerator _randomNumberGenerator;
    private readonly IResultGenerator _resultGenerator;

    private readonly Dictionary<int, string?> _difficultyRanges = new()
    {
        { 1, RangeEasy },
        { 2, RangeMedium },
        { 3, RangeHard }
    };
    
    public GuessGameService(IUserInput userInput, IRandomNumberGenerator randomNumberGenerator, IResultGenerator resultGenerator)
    {
        _userInput = userInput;
        _randomNumberGenerator = randomNumberGenerator;
        _resultGenerator = resultGenerator;
    }

    public void GuessGameAction()
    {
        try
        {
            var betAmount = _userInput.GetBetAmount();
            var difficultyLevel = _userInput.GetDifficultyLevel();
            
            var rangeToPickFrom = GetRangeInArray(_difficultyRanges.GetValueOrDefault(difficultyLevel));
            
            var userGuess = _userInput.GetUserGuess(rangeToPickFrom);
            var randomNumber = _randomNumberGenerator.GetRandomNumber(rangeToPickFrom);
            
            _resultGenerator.GetResultAndDisplay(betAmount, userGuess, randomNumber, difficultyLevel);
        }
        catch (Exception ex)
        {
            IDisplayInformation.DisplayMessage("An error occurred: " + ex.Message);
        }
    }

    private int[] GetRangeInArray(string range)
    {
        var match = Regex.Match(range, @"(\d+)\s*to\s*(\d+)");
        return new[] { int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value) };
    }
}