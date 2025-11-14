using ai_wo_generator.Models;

namespace ai_wo_generator.Services.OpenAIService
{
    public interface IOpenAIService
    {
        Task<string> GenerateTextAsync(FitnessPlanGenerate userPrompt);
    }
}
