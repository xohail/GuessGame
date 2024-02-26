using GuessGame2;
using JetBrains.Annotations;

namespace GuessGame2Tests;

[TestSubject(typeof(RandomNumberGenerator))]
public class RandomNumberGeneratorTests
{
    private readonly RandomNumberGenerator randomNumberGenerator;

    public RandomNumberGeneratorTests()
    {
        randomNumberGenerator = new RandomNumberGenerator();
    }

    [Theory]
    [InlineData(new[] { 1, 10 })] // Range from 1 to 10
    [InlineData(new[] { 10, 20 })] // Range from 10 to 20
    [InlineData(new[] { -5, 5 })] // Range from -5 to 5
    public void GetRandomNumber_ValidRange_ReturnsNumberWithinRange(int[] range)
    {
        // Act
        var result = randomNumberGenerator.GetRandomNumber(range);

        // Assert
        Assert.InRange(result, range[0], range[1]);
    }
}