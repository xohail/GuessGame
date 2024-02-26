using Microsoft.Extensions.DependencyInjection;

namespace GuessGame2;

internal abstract class GuessGameController
{
    private static void Main(string[] args)
    {
        try
        {
            ServiceCollection services = new();
            services.AddSingleton<IUserInput, UserInput>();
            services.AddSingleton<IValidateInput, ValidateInput>();
            services.AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>();
            services.AddSingleton<IResultGenerator, ResultGenerator>();
            services.AddTransient<GuessGameService>();
            var provider = services.BuildServiceProvider();

            var guessGameService = provider.GetService<GuessGameService>()!;
            guessGameService.GuessGameAction();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}