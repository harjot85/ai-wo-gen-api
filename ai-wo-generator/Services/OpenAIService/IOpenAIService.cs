namespace ai_wo_generator.Services.OpenAIService
{
    public interface IOpenAIService
    {
        Task<string> GenerateTextAsync(string prompt);
    }
}
