using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;

namespace TopTests.DAL.Repositories
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Users> FindByIdDetailsAsync(int id)
        {
            return await context.Set<Users>()
                .Where(e => e.IsDeleted == false)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Users>> FindAllUsersAsync()
        {
            return await context.Set<Users>()
                .Where(e => e.RoleOfUser==0)
                .ToListAsync();
        }

        public async Task<Users> FindByCodeOfVerificationAsync(string code)
        {
            return await context.Set<Users>()
                .Where(e => e.IsDeleted == false)
                .FirstOrDefaultAsync(e => e.CodeOfVerification == code);
        }

        public async Task<Users> FindByLoginAsync(string email)
        {
            return await context.Set<Users>()
                .Where(e => e.IsDeleted == false)
                .FirstOrDefaultAsync(e => e.Email == email);
        }
        public void DeleteAccount(int id)
        {
                      context.Set<Users>()
                     .Where(e => e.Id == id)
                     .ToList()
                     .ForEach(c => c.StatusOfVerification = "Blocked");
        }
        public void ActiveAccount(int id)
        {
            context.Set<Users>()
           .Where(e => e.Id == id)
           .ToList()
           .ForEach(c => c.StatusOfVerification = "Active");
        }
    }
}
