using RobotsManagement.Data.Context;
using RobotsManagement.Data.Contracts;
using RobotsManagement.Data.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly RobotsManagementDbContext _context;

        public UserRepository(RobotsManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }
    }
}
