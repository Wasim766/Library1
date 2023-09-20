using System;
using System.IO.Compression;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Library.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

public class StackOverflowService
{
    private readonly HttpClient _client;

    public StackOverflowService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://api.stackexchange.com/2.3/");
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<Question[]> GetLatestQuestions()
    {
        HttpResponseMessage response = await _client.GetAsync("questions?pagesize=50&order=desc&sort=creation&site=stackoverflow");
        response.EnsureSuccessStatusCode();

        using (var stream = await response.Content.ReadAsStreamAsync())
        using (var gzip = new GZipStream(stream, CompressionMode.Decompress))
        using (var reader = new StreamReader(gzip))
        {
            string content = await reader.ReadToEndAsync();
            JObject json = JObject.Parse(content);

            JArray items = (JArray)json["items"];
            return items.ToObject<Question[]>();
        }
    }

    public async Task<Question> GetQuestionDetails(int id)
    {
        HttpResponseMessage response = await _client.GetAsync($"questions/{id}?site=stackoverflow");
        response.EnsureSuccessStatusCode();

        using (var stream = await response.Content.ReadAsStreamAsync())
        using (var gzip = new GZipStream(stream, CompressionMode.Decompress))
        using (var reader = new StreamReader(gzip))
        {
            string content = await reader.ReadToEndAsync();
            JObject json = JObject.Parse(content);

            JToken item = json["items"].FirstOrDefault(); // Get the first item in "items"

            if (item != null)
            {
                return item.ToObject<Question>();
            }

            return null; // Handle case where no item is found
        }
    }


}

