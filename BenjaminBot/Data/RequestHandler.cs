namespace BenjaminBot.Data;

public class RequestHandler
{
    public async Task<string> GetBosses()
    {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync("https://data.ninjakiwi.com/btd6/bosses");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
}