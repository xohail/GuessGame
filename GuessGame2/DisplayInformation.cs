namespace GuessGame2;

public class DisplayInformation : IDisplayInformation
{
    public virtual void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public virtual void DisplayMessage(string string1, string string2, string string3, string string4)
    {
        Console.WriteLine($"{string1}\n{string2,-30}\n{string3,-30}\n{string4,-30}");
    }

    public string Display()
    {
        Console.WriteLine("What is your name");
        return Console.ReadLine();
    }
}