using ai_wo_generator.Services.OpenAIService;

namespace ai_wo_generator.Services
{
    public class FitnessPlanService(IOpenAIService openAIService) : IFitnessPlanService
    {

        public readonly IOpenAIService _openAIService = openAIService;

        public async Task<string> GetFitnessPlan(string userPrompt)
        {
            var openAIServiceResult = await _openAIService.GenerateTextAsync(userPrompt);
            return openAIServiceResult;
        }
    }
}
