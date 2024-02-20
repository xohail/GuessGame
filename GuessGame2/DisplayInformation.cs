namespace GuessGame2;

public class DisplayInformation
{
    public virtual void DisplayMessage(String message)
    {
        Console.WriteLine(message);
    }

    public virtual void DisplayMessage(String string1, String string2, String string3, String string4)
    {
        Console.WriteLine($"{string1}\n{string2,-30}\n{string3,-30}\n{string4,-30}");
    }
}