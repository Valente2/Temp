using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

// 1. Updated classes to match the Open-Meteo JSON structure
public class Response
{
    // The API returns an object called "hourly"
    public HourlyData hourly { get; set; }
}

public class HourlyData
{
    // Inside "hourly", there is a list of temperatures
    public List<double> temperature_2m { get; set; }
}

public class User
{
    public string? Name { get; set; }
    public string? Lat { get; set; }
    public string? Lng { get; set; }
}

class Program  
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        using HttpClient client = new HttpClient();
        
        User user = new User();
        Console.WriteLine("What is your name? ");
        user.Name = Console.ReadLine();
        
        Console.WriteLine("Please enter your Latitude: ");
        user.Lat = Console.ReadLine();
        
        Console.WriteLine("Please enter your Longitude: ");
        user.Lng = Console.ReadLine();

        // 2. Updated URL to use "temperature_2m" (the standard Open-Meteo field)
        string url = $"https://api.open-meteo.com/v1/forecast?latitude={user.Lat}&longitude={user.Lng}&hourly=temperature_2m";

        // 3. FIX: Change <string[]> to <Response>
        var weatherData = await client.GetFromJsonAsync<Response>(url);

        if (weatherData?.hourly?.temperature_2m != null)
        {
            // Get the first temperature in the list (current hour)
            double currentTemp = weatherData.hourly.temperature_2m[0];
            Console.WriteLine($"The temperature at your location is: {currentTemp}°C");
        }
        else 
        {
            Console.WriteLine("Could not retrieve weather data.");
        }
    }
}