using Castle.DynamicProxy;

namespace GuessGame2;

public class ResultGenerator : IResultGenerator
{
    private readonly DisplayInformation _displayInformation;

    public ResultGenerator()
    {
        var generator = new ProxyGenerator();
        var interceptor = new MethodInterceptor();
        _displayInformation = generator.CreateClassProxy<DisplayInformation>(interceptor);
    }

    public void GetResultAndDisplay(int betAmount, int guessValue, int randomNumber, int difficultyValue)
    {
        if (guessValue == randomNumber)
        {
            var prizeMoney = WinningPrizeCalculator(betAmount, difficultyValue);
            _displayInformation.DisplayMessage($"\u001b[1mCongratulations!! You have won: {prizeMoney} \u001b[0m");
        }
        else
        {
            _displayInformation.DisplayMessage("\u001b[1mSorry you lost!! :( \u001b[0m");
        }
    }

    private static int WinningPrizeCalculator(int betAmount, int difficultyValue)
    {
        return difficultyValue switch
        {
            1 => 5 * betAmount,
            2 => 10 * betAmount,
            _ => 20 * betAmount
        };
    }
}