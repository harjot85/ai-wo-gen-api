using ai_wo_generator.DTOs;
using ai_wo_generator.Models;
using ai_wo_generator.Services.OpenAIService;
using ai_wo_generator.Services.UserStats;
using System.Numerics;

namespace ai_wo_generator.Services.FitnessPlanService
{
    public class FitnessPlanService(IOpenAIService openAIService, IUserStatisticsService userStatisticsService) : IFitnessPlanService
    {

        public readonly IOpenAIService _openAIService = openAIService;
        public readonly IUserStatisticsService _userStatisticsService = userStatisticsService;

        public async Task<string> GetFitnessPlan(UserFitnessPlanParameters fitnessPlanParameters)
        {
            int userId = fitnessPlanParameters.userId;
            UserStatistics? userStatistics = await _userStatisticsService.GetUserStatistics(userId);

            if (userStatistics == null)
            {
                throw new Exception("User statistics not found.");
            }

            var prompt = CreatePromptFromFitnessPlanParametersAndStatistics(fitnessPlanParameters, userStatistics);

            var openAIServiceResult = await _openAIService.GenerateTextAsync(prompt);

            return openAIServiceResult;
        }

        private string CreatePromptFromFitnessPlanParametersAndStatistics(UserFitnessPlanParameters userPlanRequest, UserStatistics userStatistics)
        {
            var stats = userStatistics;
            var prefs = userPlanRequest.FitnessParameters.WorkoutPreferences;
            var equipment = userPlanRequest.FitnessParameters.Equipment;

            string prompt = $@"
                                Role: Expert Strength Coach. Task: Create a concise, targeted workout plan.

                                [User Stats]
                                - Sex: {stats.BiologicalSex}
                                - Age: {DateTime.Now.Year - stats.DateOfBirth.Year}
                                - Body: {stats.HeightInInches}in / {stats.WeightInLbs}lbs
                                - Exp: {stats.ExperienceLevel}
                                - Job: {stats.Profession}
                                - Limits: {stats.ChronicPhysicalLimitations ?? "None"}
                                - Medical: {stats.MedicalIssues ?? "None"}

                                [Parameters]
                                - Goal: {prefs.Goal}
                                - Sched: {prefs.NumberOfDays}
                                - Time: {prefs.WorkoutDuration}
                                - Equip: {(equipment?.Any() == true ? string.Join(", ", equipment) : "Bodyweight")}
                                - Prefs: {prefs.ExercisePreferences}

                                [Output Rules]
                                1. **Conciseness:** No intro/outro text. Use bullet points or tables only.
                                2. **Structure:** STRICTLY generate a split for {prefs.NumberOfDays} (e.g., Day 1, Day 2...).
                                3. **Content:** List Exercise, Sets, Reps. Include brief modifications for '{stats.ChronicPhysicalLimitations ?? "N/A"}' if applicable.
                                ";

            return prompt;
        }
    }
}
