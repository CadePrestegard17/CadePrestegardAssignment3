using System.Text.Json;

namespace cprestegard_sp2026_assignment3.Services
{
    public class RedditService
    {
        private readonly HttpClient _httpClient;

        public RedditService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> SearchRedditCommentsAsync(string query)
        {
            var encodedQuery = Uri.EscapeDataString(query);
            var url = $"https://api.pullpush.io/reddit/search/comment/?size=25&q={encodedQuery}";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<RedditApiResponse>(json);

                if (result?.data != null)
                {
                    return result.data
                        .Where(c => !string.IsNullOrWhiteSpace(c.body))
                        .Select(c => c.body)
                        .Take(25)
                        .ToList();
                }

                return new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }

        private class RedditApiResponse
        {
            public List<RedditComment>? data { get; set; }
        }

        private class RedditComment
        {
            public string body { get; set; } = string.Empty;
        }
    }
}
