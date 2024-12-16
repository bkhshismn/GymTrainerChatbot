namespace GymTrainerChatbot.Application.Services
{
    public class QuestionFilterService
    {
        private static readonly List<string> GymRelatedKeywords = new List<string>
        {
            "workout", "exercise", "gym", "nutrition", "fitness", "muscle", "training", "diet"
        };

        public bool IsGymRelated(string query)
        {
            return GymRelatedKeywords.Any(keyword => query.ToLower().Contains(keyword));
        }

        public string GetResponseForNonGymQuery()
        {
            return "I'm sorry, I can only answer questions related to gym, workout, fitness, and nutrition.";
        }
    }
}
