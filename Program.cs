using System;
using System.Net.Http.Json;

public class User
{
    public string? Name { get; set; }
    public string? Lat { get; set; }
    public string? Lng { get; set; }
}
class Program  
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        using HttpClient client = new HttpClient();
        Console.WriteLine("What is your name? ");
        User user = new User();
        user.Name = Console.ReadLine();
        Console.WriteLine($"Hello, {user.Name}");
        Console.WriteLine("Please enter your Latitude: ");
        user.Lat = Console.ReadLine();
        Console.WriteLine("Please enter your Longitude: ");
        user.Lng = Console.ReadLine();
        Console.WriteLine($"You are curently at {user.Lat}, {user.Lng}");


    }
}