using cprestegard_sp2026_assignment3.Models;

namespace cprestegard_sp2026_assignment3.ViewModels
{
    public class ActorDetailsViewModel
    {
        public Actor Actor { get; set; } = null!;
        public List<CommentSentimentRow> CommentSentiments { get; set; } = new List<CommentSentimentRow>();
        public OverallActorSentiment OverallSentimentData { get; set; } = new OverallActorSentiment();
    }

    public class OverallActorSentiment
    {
        public string Label { get; set; } = string.Empty;
        public double AverageCompound { get; set; }

        public string GetDisplayString()
        {
            if (string.IsNullOrEmpty(Label))
                return "No sentiment data available";

            return $"Overall Sentiment: {Label} (Avg Compound: {AverageCompound:F2})";
        }
    }
}
