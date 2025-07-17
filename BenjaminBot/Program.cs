using BenjaminBot.Data;
using NetCord;
using NetCord.Gateway;
using NetCord.Logging;

namespace BenjaminBot;

public static class Program
{
    public static GatewayClient Client { get; private set; }

    public static readonly RequestHandler Requests = new RequestHandler();
    public static readonly DataParser Parser = new DataParser();
    
    static async Task Main(string[] args)
    {
        DotNetEnv.Env.Load();
        string? token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");
        
        if (token is null)
        {
            Console.WriteLine("No token found");
            return;
        }
        
        Client = new GatewayClient(new BotToken(token), new GatewayClientConfiguration
        {
            Logger = new ConsoleLogger(),
            // Intents = GatewayIntents.All
        });

        Client.Ready += async readyArgs => await OnReady(readyArgs);
        
        await Client.StartAsync();
        await Task.Delay(-1);
    }

    private static async Task OnReady(ReadyEventArgs readyArgs)
    {
        await Parser.ParseBossesData();
    }
}