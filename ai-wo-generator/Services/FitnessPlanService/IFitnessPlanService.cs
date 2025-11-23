using ai_wo_generator.Models;

namespace ai_wo_generator.Services.FitnessPlanService
{
    public interface IFitnessPlanService
    {
        Task<string> GetFitnessPlan(FitnessPlanGenerate userPrompt);
    }
}
