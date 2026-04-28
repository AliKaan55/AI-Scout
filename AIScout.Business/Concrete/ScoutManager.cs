using AIScoutProject.AIScout.Business.Abstract;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AIScoutProject.AIScout.Business.Concrete
{
    public class ScoutManager : IScoutService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-3.1-flash-lite-preview:generateContent";
        public ScoutManager(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            
            _apiKey = configuration["GeminiSettings:ApiKey"];
        }

        public async Task<string> GetRecommendationsAsync(string playerName)
        {
            if (string.IsNullOrEmpty(_apiKey))
                return "Hata: API Anahtarı bulunamadı! Lütfen ayarları kontrol edin.";  
            var prompt = $"{playerName} futbolcusuna benzer oyun stiline sahip, 23 yaş altı 3 genç yetenek öner. Oyuncuların güncel yaşlarını ve takımlarını kontrol ederek, 2026 yılı itibarıyla kesin bilgiler ver.";

            var requestObject = new
            {
                contents = new[]
                {
            new { parts = new[] { new { text = prompt } } }
        }
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestObject), Encoding.UTF8, "application/json");

            try
            {
                
                var response = await _httpClient.PostAsync($"{_apiUrl}?key={_apiKey.Trim()}", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(jsonResponse);
                    return result.candidates[0].content.parts[0].text;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    return $"API Hatası: {response.StatusCode} - {errorBody}";
                }
            }
            catch (Exception ex)
            {
                return $"Bağlantı Hatası: {ex.Message}";
            }
        }
    }
}