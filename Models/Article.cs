using Newtonsoft.Json;

public class Article {
    public int id { get; set; }

    public string title { get; set;}

    public string content { get; set; }

    public int memberid { get; set; }
    [JsonIgnore]
    public Member Member { get; set; }

}