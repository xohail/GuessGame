using GuessGame2;
using JetBrains.Annotations;
using Moq;
using NUnit.Framework;
using System.Text;
using Assert2 = Xunit.Assert;


namespace GuessGame2Tests;

[TestSubject(typeof(DisplayInformation))]
public class DisplayInformationTest
{
    private StringBuilder _consoleOutput;
    private Mock<TextReader> _consoleInput;
    private DisplayInformation _displayInformation;

    [SetUp]
    public void Setup()
    {
        _consoleOutput = new StringBuilder();
        var consoleOutputWriter = new StringWriter(_consoleOutput);
        _consoleInput = new Mock<TextReader>();
        Console.SetOut(consoleOutputWriter);
        Console.SetIn(_consoleInput.Object);
        
        _displayInformation = new();
    }

    [Test]
    public void TestDisplay()
    {
        SetupUserResponses("Jason", "10", "20");
        var expectedPrompt = "What is your name";

        _displayInformation.Display();
        var outputLines = _consoleOutput.ToString().Split("\n");
        Assert2.Equal(expectedPrompt, outputLines[0]);
    }

    [Test]
    public void TestDisplayMessageSingleString()
    {
        var expectedPrompt = "\u001b[1mWelcome to the Guess Game!!!";
        _displayInformation.DisplayMessage("\u001b[1mWelcome to the Guess Game!!!");
        var outputLines = _consoleOutput.ToString().Split("\n");
        Assert2.Equal(expectedPrompt, outputLines[0]);

    }
    
    [Test]
    public void TestDisplayMessageMultiString()
    {
        var expectedPrompt1 = "str1";
        var expectedPrompt2 = "str2                          ";
        var expectedPrompt3 = "str3                          ";
        var expectedPrompt4 = "str4                          ";
        _displayInformation.DisplayMessage("str1", "str2", "str3", "str4");
        var outputLines = _consoleOutput.ToString().Split("\n");
        Assert2.Equal(expectedPrompt1, outputLines[0]);
        Assert2.Equal(expectedPrompt2, outputLines[1]);
        Assert2.Equal(expectedPrompt3, outputLines[2]);
        Assert2.Equal(expectedPrompt4, outputLines[3]);

    }

    private MockSequence SetupUserResponses(params string[] responses)
    {
        var sequence = new MockSequence();
        foreach (var response in responses)
        {
            _consoleInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns(response);
        }
        return sequence;
    }
}