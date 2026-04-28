namespace AIScoutProject.AIScout.Core.Entities
{
    public class ScoutRecommendation
    {
        public int Id { get; set; }
        public string SuggestedPlayerName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string SimilarityScore { get; set; } = string.Empty;
        public int BasedOnPlayerId { get; set; }
    }
}