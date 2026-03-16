using System;

public class User
{
    public string? Name { get; set; }
}
class Program  
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Console.WriteLine("What is your name? ");
        User user = new User();
        user.Name = Console.ReadLine();
        Console.WriteLine($"Hello, {user.Name}");
    }
}