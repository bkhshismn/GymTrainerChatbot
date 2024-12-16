using Xunit;
using GymTrainerChatbot.Application.Services;

namespace GymTrainerChatbot.Tests
{
    public class QuestionFilterServiceTests
    {
        private readonly QuestionFilterService _service;

        public QuestionFilterServiceTests()
        {
            _service = new QuestionFilterService();
        }

        [Fact]
        public void IsGymRelated_ShouldReturnTrue_WhenQueryIsGymRelated()
        {
            var result = _service.IsGymRelated("Tell me about workout plans");
            Assert.True(result);
        }

        [Fact]
        public void IsGymRelated_ShouldReturnFalse_WhenQueryIsNotGymRelated()
        {
            var result = _service.IsGymRelated("What is the weather today?");
            Assert.False(result);
        }
    }
}
