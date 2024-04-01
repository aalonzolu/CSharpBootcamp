using Newtonsoft.Json;

public class Book
{
    [JsonProperty("id")]
    public int ID { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("author")]
    public string Author { get; set; }
}