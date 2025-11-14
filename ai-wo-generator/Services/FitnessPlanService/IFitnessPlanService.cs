using ai_wo_generator.Models;

namespace ai_wo_generator.Services
{
    public interface IFitnessPlanService
    {
        Task<string> GetFitnessPlan(FitnessPlanGenerate userPrompt);
    }
}
