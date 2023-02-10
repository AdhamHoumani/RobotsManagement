using RobotsManagement.Data.Repository.Models;
using RobotsManagement.Service.Models.Request;
using RobotsManagement.Service.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Service.Interfaces
{
    public interface IRobotService
    {
        ServiceResponse Add(AddRobotRequest request);
        ServiceResponse Delete(DeleteRobotRequest request);
        ServiceResponse GetAll();
        ServiceResponse GetByUserId(GetRobotsByUserIdRequest request);
        ServiceResponse GetRobotTypes();
        ServiceResponse Update(UpdateRobotRequest request);
    }
}
