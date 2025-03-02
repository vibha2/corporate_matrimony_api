using CorporateMatrimony.API.Entities;

namespace CorporateMatrimony.API.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<IEnumerable<User>> GetAllUsersSP();


    }
}
