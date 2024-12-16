
using GymTrainerChatbot.Application.Exceptions;
using GymTrainerChatbot.Domain.DTOs;
using GymTrainerChatbot.Domain.Entities;
using GymTrainerChatbot.Domain.Interfaces;

namespace GymTrainerChatbot.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return new UserDto { Id = user.Id, Username = user.Username };
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDto { Id = u.Id, Username = u.Username });
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            var user = new User { Username = userDto.Username, CreatedAt = DateTime.Now };
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {

            var user = await _userRepository.GetByIdAsync(userDto.Id);

            if (user == null)
            {
                throw new NotFoundException($"User with id {userDto.Id} not found.");
            }


            user.Username = userDto.Username;
            user.UpdatedAt = DateTime.Now;


            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException($"User with id {id} not found.");
            }


            await _userRepository.DeleteAsync(id);
        }


    }
}
