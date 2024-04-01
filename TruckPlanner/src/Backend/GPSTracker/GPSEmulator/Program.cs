// See https://aka.ms/new-console-template for more information
using GPSEmulator;
using StackExchange.Redis;
using System.Text.Json;

Console.WriteLine("Start GPS Publisher");

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

IDatabase db = redis.GetDatabase();
string channelName = "truckChannel";

var truckCoordinates = new TruckCoordinates
{
    DriverId = 1,
    Latitude = 0,
    Longitude = 0,
};

string jsonMessage = JsonSerializer.Serialize(truckCoordinates);

Timer timer = new Timer(state =>
{

    db.Publish(channelName, jsonMessage);

    Console.WriteLine($"Message published at {DateTime.Now}");
}, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

Console.ReadLine();

timer.Dispose();
redis.Close();


