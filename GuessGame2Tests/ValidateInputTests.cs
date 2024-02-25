using GuessGame2;

namespace GuessGame2Tests
{
    public class ValidateInputTests
    {
        private readonly ValidateInput _validateInput = new();

        [Fact]
        public void ValidateIntAndNotZero_InputValid_ReturnsParsedValue()
        {
            // Arrange
            string input = "10";
            
            // Act
            int result = _validateInput.ValidateIntAndNotZero(input);
            
            // Assert
            Assert.Equal(10, result);
        }
        
        [Fact]
        public void ValidateIntAndNotZero_InputZero_ThrowsException()
        {
            // Arrange
            string input = "0";
            
            // Act and Assert
            var exception = Assert.Throws<Exception>(() => _validateInput.ValidateIntAndNotZero(input));
            Assert.Equal("Betting amount should not be zero or less than zero", exception.Message);
        }
        
        [Fact]
        public void ValidateIntAndNotZero_InputNegative_ThrowsException()
        {
            // Arrange
            string input = "-1";
            
            // Act and Assert
            var exception = Assert.Throws<Exception>(() => _validateInput.ValidateIntAndNotZero(input));
            Assert.Equal("Value should not be zero or less than zero", exception.Message);
        }
        
        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("3", 3)]
        public void ValidateDifficultyValue_ValidInput_ReturnsParsedValue(string input, int expected)
        {
            // Act
            int result = _validateInput.ValidateDifficultyValue(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("4")]
        public void ValidateDifficultyValue_InvalidInput_ThrowsException(string input)
        {
            // Act and Assert
            var exception = Assert.Throws<Exception>(() => _validateInput.ValidateDifficultyValue(input));
            Assert.Equal("Difficulty value is not valid.", exception.Message);
        }

        [Theory]
        [InlineData("5", new[] { 1, 10 })]
        [InlineData("15", new[] { 1, 20 })]
        public void ValidateGuessValue_ValidInput_ReturnsParsedValue(string input, int[] range)
        {
            // Act
            int result = _validateInput.ValidateGuessValue(input, range);

            // Assert
            Assert.Equal(int.Parse(input), result);
        }

        [Theory]
        [InlineData("7", new[] { 1, 5 })]
        [InlineData("10", new[] { 1, 5 })]
        public void ValidateGuessValue_InvalidInput_ThrowsException(string input, int[] range)
        {
            // Act and Assert
            var exception = Assert.Throws<Exception>(() => _validateInput.ValidateGuessValue(input, range));
            Assert.Equal($"Guess value is not in range of {range}.", exception.Message);
        }
    }
}