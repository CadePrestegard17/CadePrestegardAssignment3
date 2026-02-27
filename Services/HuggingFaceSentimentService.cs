using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace cprestegard_sp2026_assignment3.Services
{
    public class HuggingFaceSentimentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public HuggingFaceSentimentService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["HuggingFaceApiKey"] ?? string.Empty;
        }

        public async Task<SentimentResult> AnalyzeSentimentAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new SentimentResult { Label = "NEUTRAL", Score = 0.0 };
            }

            var url = "https://router.huggingface.co/hf-inference/models/distilbert/distilbert-base-uncased-finetuned-sst-2-english";

            try
            {
                var requestBody = new
                {
                    inputs = TruncateToMaxLength(text, 512)
                };

                var jsonContent = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var results = JsonSerializer.Deserialize<List<List<HuggingFaceResult>>>(jsonResponse);

                if (results != null && results.Count > 0 && results[0].Count > 0)
                {
                    var topResult = results[0].OrderByDescending(r => r.score).First();
                    return new SentimentResult
                    {
                        Label = topResult.label.ToUpper(),
                        Score = topResult.score
                    };
                }

                return new SentimentResult { Label = "NEUTRAL", Score = 0.0 };
            }
            catch
            {
                return new SentimentResult { Label = "NEUTRAL", Score = 0.0 };
            }
        }

        private string TruncateToMaxLength(string text, int maxLen)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= maxLen)
                return text;

            return text.Substring(0, maxLen);
        }

        private class HuggingFaceResult
        {
            public string label { get; set; } = string.Empty;
            public double score { get; set; }
        }
    }

    public class SentimentResult
    {
        public string Label { get; set; } = string.Empty;
        public double Score { get; set; }

        public string GetDisplayString()
        {
            return $"{Label}: {Score:F2}";
        }

        public double GetSignedScore()
        {
            return Label == "NEGATIVE" ? -Score : Score;
        }
    }
}
