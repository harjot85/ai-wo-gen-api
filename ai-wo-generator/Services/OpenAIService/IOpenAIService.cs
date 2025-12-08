using ai_wo_generator.DTOs;

namespace ai_wo_generator.Services.OpenAIService
{
    public interface IOpenAIService
    {
        Task<string> GenerateTextAsync(FitnessPlanGenerate userPrompt);
    }
}
