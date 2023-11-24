using System.Diagnostics.CodeAnalysis;

namespace DemoNullableReferenceType;

public class ChatUser
{
    private Random Rnd = new();
    private string _nickname="";

    // user 可能設值時，沒有給值，所以要考慮 nullable
    public string NickName
    {
        get => _nickname;
        set => _nickname = value ?? RandomNickName();
    }

    private string RandomNickName() => $"Guest{Rnd.Next(1,1000)}";

    public void DoChat()
    {
        Console.WriteLine("Welcome to Chat Center");
        Console.Write("Please enter your nickname");
        NickName = Console.ReadLine();

        // do chat things
    }
}
