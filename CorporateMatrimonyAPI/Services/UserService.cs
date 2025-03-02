using CorporateMatrimony.API.Entities;
using CorporateMatrimony.API.Interfaces;
using CorporateMatrimony.API.Repositories;

namespace CorporateMatrimony.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return _userRepository.GetAllUsersSP();
        }
    }
}
