using GymTrainerChatbot.Domain.DTOs;


namespace GymTrainerChatbot.Domain.Interfaces
{
    public interface ITrainingSessionService
    {
        Task<IEnumerable<TrainingSessionDto>> GetSessionsForUserAsync(int userId);
        Task CreateSessionAsync(TrainingSessionDto sessionDto);
        Task UpdateSessionAsync(TrainingSessionDto sessionDto);
        Task DeleteSessionAsync(int id);
    }
}
