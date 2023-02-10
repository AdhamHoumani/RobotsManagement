using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Service.Models.DTO
{
    public class UsersRobotDTO
    {
        public string? Id { get; set; }
        public string? Owner { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? TypeId { get; set; }
        public string? Model { get; set; }
        public int? ModelId { get; set; }
    }
}
