using GymTrainerChatbot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTrainerChatbot.Domain.Interfaces
{
    public interface ITrainingSessionRepository
    {
        Task<TrainingSession> GetByIdAsync(int id);
        Task<IEnumerable<TrainingSession>> GetSessionsForUserAsync(int userId);
        Task AddAsync(TrainingSession session);
        Task UpdateAsync(TrainingSession session);
        Task DeleteAsync(int id);
    }
}
