using CorporateMatrimony.API.Entities;
using CorporateMatrimony.API.Helpers;
using CorporateMatrimony.API.Interfaces;

namespace CorporateMatrimony.API.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IDatabaseHelper  _databaseHelper;
        private readonly IDatabaseHelperSP _databaseHelperSP;
        public UserRepository(IDatabaseHelper databaseHelper, IDatabaseHelperSP databaseHelperSP) 
        {
            _databaseHelper =  databaseHelper;
            _databaseHelperSP = databaseHelperSP;
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            var query = "Select * from Auth.Users";
            return _databaseHelper.QueryAsync<User>(query);
        }

        public Task<IEnumerable<User>> GetAllUsersSP()
        {
            StoreProcedureParams sp = new StoreProcedureParams();
            sp.ProcedureName = "[Auth].[spGetAllUsers]";
            return _databaseHelperSP.QueryAsync<User>(sp);
        }

    }
}
