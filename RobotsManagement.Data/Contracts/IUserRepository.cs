using RobotsManagement.Data.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Data.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
