using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

public class Root
{
    
    public static Root GetJoke()
    {
        var key = File.ReadAllText("appsettings.json");
        var apiKey = JObject.Parse(key).GetValue("DefaultKey").ToString();

        var client = new RestClient("https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random");
        var request = new RestRequest();
        request.AddHeader("accept", "application/json");
        request.AddHeader("X-RapidAPI-Key", $"{apiKey}");
        request.AddHeader("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
        var response = client.Execute(request);

        var root = JsonConvert.DeserializeObject<Root>(response.Content);

        return root;
    }

    [JsonProperty("categories")]
    public List<object>? Categories { get; set; }

    [JsonProperty("created_at")]
    public string? CreatedAt { get; set; }

    [JsonProperty("icon_url")]
    public string? IconUrl { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("value")]
    public string? Value { get; set; }
}
