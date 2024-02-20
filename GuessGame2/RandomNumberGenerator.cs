namespace GuessGame2;

public class RandomNumberGenerator
{
    private readonly Random random = new();

    public int GetRandomNumber(int[] range)
    {
        return random.Next(range[0], range[1] + 1);
    }
}