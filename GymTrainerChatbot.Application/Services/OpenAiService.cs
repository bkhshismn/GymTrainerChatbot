using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GymTrainerChatbot.Domain.DTOs;
using Newtonsoft.Json;

namespace GymTrainerChatbot.Application.Services
{
    public class OpenAiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = "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"; 
        }

        public async Task<string> GetChatbotResponseAsync(string userQuery)
        {
            var requestData = new
            {
                model = "gpt-3.5-turbo", 
                messages = new[]
                {
                    new { role = "user", content = userQuery }
                }
            };

            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(responseData);
                return result.choices[0].message.content;
            }
            else
            {
                return "Error: Unable to process the request.";
            }
        }
    }
}
