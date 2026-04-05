
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Api.Services
{
    public class AIService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public AIService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> AnalyzeInputAsync(string input)
        {
            var apiKey = _config["AI:ApiKey"];

            var prompt = $@"
You are a senior enterprise developer assistant.

Analyze the following input and respond with:
1. Explanation
2. Possible issues
3. Suggested fix or improvement

Input:
{input}
";

            var requestBody = new
            {
                model = "claude-3-sonnet-20240229",
                max_tokens = 500,
                messages = new[]
                {
                    new {
                        role = "user",
                        content = prompt
                    }
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.anthropic.com/v1/messages");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            request.Headers.Add("anthropic-version", "2023-06-01");

            request.Content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
}
