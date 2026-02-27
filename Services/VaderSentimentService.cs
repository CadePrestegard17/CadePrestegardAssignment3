using VaderSharp2;

namespace cprestegard_sp2026_assignment3.Services
{
    public class VaderSentimentService
    {
        private readonly SentimentIntensityAnalyzer _analyzer;

        public VaderSentimentService()
        {
            _analyzer = new SentimentIntensityAnalyzer();
        }

        public VaderSentimentResult AnalyzeSentiment(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new VaderSentimentResult
                {
                    Label = "NEUTRAL",
                    CompoundScore = 0.0,
                    PositiveScore = 0.0,
                    NegativeScore = 0.0,
                    NeutralScore = 0.0
                };
            }

            var results = _analyzer.PolarityScores(text);

            return new VaderSentimentResult
            {
                Label = LabelFromVaderCompound(results.Compound),
                CompoundScore = results.Compound,
                PositiveScore = results.Positive,
                NegativeScore = results.Negative,
                NeutralScore = results.Neutral
            };
        }

        private string LabelFromVaderCompound(double compound)
        {
            if (compound >= 0.05)
                return "POSITIVE";
            else if (compound <= -0.05)
                return "NEGATIVE";
            else
                return "NEUTRAL";
        }
    }

    public class VaderSentimentResult
    {
        public string Label { get; set; } = string.Empty;
        public double CompoundScore { get; set; }
        public double PositiveScore { get; set; }
        public double NegativeScore { get; set; }
        public double NeutralScore { get; set; }

        public string GetDisplayString()
        {
            // Convert to percentage (0-1 scale to 0-100)
            var displayScore = GetDisplayScore() * 100;
            return $"{Label}: {displayScore:F2}";
        }

        public double GetDisplayScore()
        {
            // Return the dominant score based on the label
            return Label switch
            {
                "POSITIVE" => PositiveScore,
                "NEGATIVE" => NegativeScore,
                "NEUTRAL" => NeutralScore,
                _ => 0.0
            };
        }

        public double GetSignedCompound()
        {
            return CompoundScore;
        }
    }
}
