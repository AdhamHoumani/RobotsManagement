using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Service.Models.Responses
{
    public class ServiceResponse
    {
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
    }
}
