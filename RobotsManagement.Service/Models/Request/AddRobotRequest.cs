using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Service.Models.Request
{
    public class AddRobotRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
    }
}
