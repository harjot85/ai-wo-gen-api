namespace ai_wo_generator.Services
{
    public interface IFitnessPlanService
    {
        Task<string> GetFitnessPlan(string userPrompt);
    }
}
