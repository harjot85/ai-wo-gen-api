using ai_wo_generator.DTOs;

namespace ai_wo_generator.Services.FitnessPlanService
{
    public interface IFitnessPlanService
    {
        Task<string> GetFitnessPlan(UserFitnessPlanParameters userPrompt);
    }
}
