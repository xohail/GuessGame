using Microsoft.Extensions.DependencyInjection;

namespace GuessGame2;

internal abstract class GuessGameController
{
    private static void Main(string[] args)
    {
        ServiceCollection services = new();
        services.AddSingleton<IUserInput, UserInput>();
        services.AddSingleton<IValidateInput, ValidateInput>();
        services.AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>();
        services.AddSingleton<IResultGenerator, ResultGenerator>();
        services.AddSingleton<IDisplayInformation, DisplayInformation>();
        services.AddTransient<GuessGameService>();
        var provider = services.BuildServiceProvider();

        GuessGameService guessGameService = provider.GetService<GuessGameService>()!;
        guessGameService.GuessGameAction();
    }
}