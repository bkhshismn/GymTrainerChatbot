using Microsoft.AspNetCore.Mvc;
using GymTrainerChatbot.Application.Services;
using GymTrainerChatbot.Domain.DTOs;

namespace GymTrainerChatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly OpenAiService _openAiService;
        private readonly QuestionFilterService _questionFilterService;

        public ChatController(OpenAiService openAiService, QuestionFilterService questionFilterService)
        {
            _openAiService = openAiService;
            _questionFilterService = questionFilterService;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] UserQueryDto userQuery)
        {
            if (_questionFilterService.IsGymRelated(userQuery.Query))
            {
                var response = await _openAiService.GetChatbotResponseAsync(userQuery.Query);
                return Ok(new { response });
            }
            else
            {
                var response = _questionFilterService.GetResponseForNonGymQuery();
                return Ok(new { response });
            }
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok(new { status = "API is up and running" });
        }
    }
}
