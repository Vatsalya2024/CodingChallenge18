using CodingChallenge.Models.DTOs;
using CodingChallenge.Models;

namespace CodingChallenge.Interfaces
{
    public interface IUserService
    {
        public Task<User> AddUser(User user);
        public Task<User> RemoveUser(int id);
        public Task<User> GetUser(int userId);
        public Task<List<User>> GetAllUser();
       
        public Task<User> Login(LoginDTO loginDTO);
    }
}
