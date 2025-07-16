using NetCord;
using NetCord.Gateway;
using NetCord.Logging;

namespace BenjaminBot;

static class Program
{
    static async Task Main(string[] args)
    {
        DotNetEnv.Env.Load();
        string? token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");

        if (token is null)
        {
            Console.WriteLine("No token found");
            return;
        }
        
        GatewayClient client = new(new BotToken(token), new GatewayClientConfiguration
        {
            Logger = new ConsoleLogger(),
        });

        string json = await GetBosses();
        await client.Rest.SendMessageAsync(1271785546544320512, $"```json\n{json.Substring(0, 1988)}\n```");
        
        await client.StartAsync();
        await Task.Delay(-1);
    }
    
    public static async Task<string> GetBosses()
    {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync("https://data.ninjakiwi.com/btd6/bosses");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
}