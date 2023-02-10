using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using RobotsManagement.Data.Repository.Models;
using RobotsManagement.Service.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Service.Models.Mapping
{
    public class MapperProfile : Profile
    {
        private readonly IDataProtector _protector;
        public MapperProfile(IDataProtector protector)
        {
            _protector = protector;

            CreateMap<User, UserDTO>()
                .ForMember(des => des.Id,
                opt => opt.MapFrom(src => _protector.Protect(src.Id.ToString())));

            CreateMap<Robot, UsersRobotDTO>()
                .ForMember(des => des.Id,
                opt => opt.MapFrom(src => _protector.Protect(src.Id.ToString())))
                .ForMember(des => des.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.TypeId,
                opt => opt.MapFrom(src => src.RobotTypeId))
                .ForMember(des => des.Type,
                opt => opt.MapFrom(src => src.RobotType.Name))
                .ForMember(des => des.ModelId,
                opt => opt.MapFrom(src => src.RobotType.ModelId))
                .ForMember(des => des.Model,
                opt => opt.MapFrom(src => src.RobotType.Model))
                .ForMember(des => des.Owner,
                opt => opt.MapFrom(src => src.User != null ? $"{src.User.FirstName} {src.User.LastName}" : "UnAssigned"));

            CreateMap<Robot, RobotDTO>()
               .ForMember(des => des.Id,
               opt => opt.MapFrom(src => _protector.Protect(src.Id.ToString())))
               .ForMember(des => des.Name,
               opt => opt.MapFrom(src => src.Name))
               .ForMember(des => des.Type,
               opt => opt.MapFrom(src => src.RobotType.Name))
               .ForMember(des => des.Model,
               opt => opt.MapFrom(src => src.RobotType.Model.Name));

        }
    }
}
