using CodingChallenge.Interfaces;
using CodingChallenge.Models.DTOs;
using CodingChallenge.Models;
using CodingChallenge.Repositories;

namespace CodingChallenge.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepository;

        public UserService(IRepository<int, User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> AddUser(User user)
        {
            return await _userRepository.Add(user);
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await _userRepository.Get(userId);
            if (user != null)
            {
                return user;
            }
            throw new NoSuchUserException();
        }

        public async Task<User> Login(LoginDTO loginDTO)
        {
            var users = await _userRepository.GetAll();
            var user = users.FirstOrDefault(e => e.UserName == loginDTO.Username && e.Password == loginDTO.Password);

            if (user != null)
            {
                return user;
            }
            throw new NoSuchUserException();
        }

        public async Task<User> RemoveUser(int id)
        {
            var users = await _userRepository.Get(id);
            if (users != null)
            {
                _userRepository.Delete(id);
                return users;
            }
            throw new NoSuchUserException();
        }



    }

}
