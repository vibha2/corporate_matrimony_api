using CorporateMatrimony.API.Entities;

namespace CorporateMatrimony.API.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();

    }
}
