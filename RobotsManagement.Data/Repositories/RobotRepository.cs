using RobotsManagement.Data.Context;
using RobotsManagement.Data.Contracts;
using RobotsManagement.Data.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Data.Repositories
{
    public class RobotRepository : GenericRepository<Robot>, IRobotRepository
    {
        private readonly RobotsManagementDbContext _context;
        public RobotRepository(RobotsManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Robot> GetByUserId(int userId)
        {
            return _context.Robots.Where(r => r.UserId == userId)
                .Include(r=>r.User)
                .Include(r=>r.RobotType)
                .ThenInclude(t=>t.Model).ToList();
        }
    }
}
