using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;

namespace TopTests.DAL.Interfaces
{
    public interface IUserRepository : IRepositoryBase<Users>
    {
        Task<Users> FindByIdDetailsAsync(int id);
        Task<IEnumerable<Users>> FindAllUsersAsync();
        Task<Users> FindByCodeOfVerificationAsync(string code);
        Task<Users> FindByLoginAsync(string email);
        void DeleteAccount(int id);
        void ActiveAccount(int id);
    }
}
