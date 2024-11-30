using System;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Program
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task Main(string[] args)
    {
        try
        {
            // Ställ in User-Agent för GitHub API som krävs för att göra anrop
            client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");

            // API URL:en
            string url = "https://api.github.com/orgs/dotnet/repos";

            // Skickar HTTP GET-förfrågan
            var response = await client.GetAsync(url);

            // Kontrollerar om svaret är framgångsrikt eller inte
            response.EnsureSuccessStatusCode();

            // Läs svaret som en JSON-sträng
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserialisera JSON till en lista av GitHubRepo-objekt
            var repositories = JsonSerializer.Deserialize<List<GitHubRepo>>(jsonResponse);

            // Skriver ut resultaten
            foreach (var repo in repositories)
            {
                Console.WriteLine($"Name: {repo.Name}");
                Console.WriteLine($"Homepage: {repo.Homepage}");
                Console.WriteLine($"GitHub: {repo.HtmlUrl}");
                Console.WriteLine($"Description: {repo.Description}");
                Console.WriteLine($"Watchers: {repo.Watchers}");
                Console.WriteLine($"Last Pushed: {repo.PushedAt}");
                Console.WriteLine(new string('-', 50));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade: {ex.Message}");
        }
    }
}