using RobotsManagement.Service.Models.Request;
using RobotsManagement.Service.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Service.Interfaces
{
    public interface IAuthService
    {
        ServiceResponse Login(LoginRequest request);
    }
}
