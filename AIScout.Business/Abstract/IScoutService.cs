namespace AIScoutProject.AIScout.Business.Abstract
{
    public interface IScoutService
    {
        Task<string> GetRecommendationsAsync(string playerName);
    }
}