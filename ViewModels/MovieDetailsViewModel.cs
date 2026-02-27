using cprestegard_sp2026_assignment3.Models;

namespace cprestegard_sp2026_assignment3.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; } = null!;
        public List<CommentSentimentRow> CommentSentiments { get; set; } = new List<CommentSentimentRow>();
        public OverallSentiment OverallSentimentData { get; set; } = new OverallSentiment();
    }

    public class CommentSentimentRow
    {
        public string CommentText { get; set; } = string.Empty;
        public string SentimentDisplay { get; set; } = string.Empty;
    }

    public class OverallSentiment
    {
        public string Label { get; set; } = string.Empty;
        public double AverageScore { get; set; }

        public string GetDisplayString()
        {
            if (string.IsNullOrEmpty(Label))
                return "No sentiment data available";

            return $"Overall Sentiment: {Label} (Avg: {AverageScore:F2})";
        }
    }
}
