namespace BenjaminBot.Data;

public class DataParser
{
    public async Task ParseBossesData()
    {
        string json = await Program.Requests.GetBosses();
        
        // For testing purposes send raw json to test channel
        await Program.Client.Rest.SendMessageAsync(1271785546544320512, $"```json\n{json.Substring(0, 1988)}\n```");
    }
}