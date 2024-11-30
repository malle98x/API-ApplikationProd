using System;
using System.Text.Json.Serialization;

public class GitHubRepo
{
    [JsonPropertyName("name")]
    public string? Name { get; set; } // Nullable

    [JsonPropertyName("description")]
    public string? Description { get; set; } // Nullable

    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; set; } // Nullable

    [JsonPropertyName("homepage")]
    public string? Homepage { get; set; } // Nullable

    [JsonPropertyName("watchers")]
    public int Watchers { get; set; }

    [JsonPropertyName("pushed_at")]
    public DateTime PushedAt { get; set; }
}