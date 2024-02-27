# GuessGame

## Description
Develop a .NET console game where the user guesses a number within a specified range. If the user's guess matches the randomly generated number by the program, they win a prize.
## Task
    - Get user input for the amount he wants to bet
    - Show Game difficulty level
        1) Easy -> 1 to 5 
        2) Medium -> 1 to 10 
        3) Hard -> 1 to 20
    - Get user input to choose difficulty (1,2 or 3)
    - Get user input between the range of the chosen difficulty e.g "5" if the user chooses option#1
    - If the guess is wrong, show Sorry you lost!
    - If the guess is correct, the prize amount is calculated by
        1 => 5 * betAmount,
        2 => 10 * betAmount,
        3 => 20 * betAmount

## Technical details
    - .NET 7 
    - C#
    - Console application
    - Unit testing with Moq, Xunit and Nunit
    - Clean code using SOLID principals
    - Dependency Injection using ServiceCollection




