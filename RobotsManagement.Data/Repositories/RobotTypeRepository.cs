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
    public class RobotTypeRepository : GenericRepository<RobotType>, IRobotTypeRepository
    {
        public RobotTypeRepository(RobotsManagementDbContext context) : base(context)
        {
        }
    }
}
