namespace GuessGame2;

public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _random = new();

    public int GetRandomNumber(int[] range)
    {
        return _random.Next(range[0], range[1] + 1);
    }
}