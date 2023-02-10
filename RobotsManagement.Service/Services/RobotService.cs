using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using RobotsManagement.Data.Contracts;
using RobotsManagement.Data.Enums;
using RobotsManagement.Data.Repository.Models;
using RobotsManagement.Service.Enum;
using RobotsManagement.Service.Interfaces;
using RobotsManagement.Service.Models.DTO;
using RobotsManagement.Service.Models.Request;
using RobotsManagement.Service.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Service.Services
{
    public class RobotService : IRobotService
    {
        private readonly IRobotRepository _robotRepository;
        private readonly IRobotTypeRepository _robotTypeRepository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;
        public RobotService(IRobotRepository robotRepository, IMapper mapper, IDataProtector protector, IRobotTypeRepository robotTypeRepository)
        {
            _robotRepository = robotRepository;
            _mapper = mapper;
            _protector = protector;
            _robotTypeRepository = robotTypeRepository;
        }

        public ServiceResponse GetAll() {
            var robots = _robotRepository.GetAll();
            var robotDtos = _mapper.Map<UsersRobotDTO>(robots);
            return new ServiceResponse
            {
                Data = robotDtos,
                Status = (int)ResponseStatusEnum.Success
            };
        }

        public ServiceResponse GetByUserId(GetRobotsByUserIdRequest request)
        {
            int userId = int.Parse(_protector.Unprotect(request.UserId));
            var robots = _robotRepository.GetByUserId(userId);
            var robotDTOs = _mapper.Map<List<RobotDTO>>(robots);
            return new ServiceResponse
            {
                Data = robotDTOs,
                Status = (int)ResponseStatusEnum.Success
            };
        }

        public ServiceResponse GetRobotTypes()
        {
            var types = _robotTypeRepository.GetAll();
            return new ServiceResponse
            {
                Data = types,
                Status = (int)ResponseStatusEnum.Success
            };
        }

        public ServiceResponse Add(AddRobotRequest request)
        {
            var type = _robotTypeRepository.GetAll().FirstOrDefault(t=>t.Name == request.Type);
            if(type == null){
                return new ServiceResponse
                {
                    Message = "Invalid Type",
                    Status = (int)ResponseStatusEnum.Failer
                };
            }
            int? userId = int.Parse(_protector.Unprotect(request.UserId));
            var robot = new Robot
            {
                Id = 0,
                Name = request.Name,
                RobotTypeId = type.Id,
                UserId = userId
            };
            _robotRepository.Insert(robot);
            return new ServiceResponse
            {
                Data = true,
                Status = (int)ResponseStatusEnum.Success,
                Message = "Added Successfully"
            };
        }

        public ServiceResponse Update(UpdateRobotRequest request)
        {
            var type = _robotTypeRepository.GetAll().FirstOrDefault(t => t.Name == request.Type);
            if (type == null)
            {
                return new ServiceResponse
                {
                    Message = "Invalid Type",
                    Status = (int)ResponseStatusEnum.Failer
                };
            }
            int robotId = int.Parse(_protector.Unprotect(request.Id));
            int userId = int.Parse(_protector.Unprotect(request.UserId));
            var robotToUpdate = new Robot
            {
                Id = robotId,
                UserId = userId,
                Name = request.Name,
                RobotTypeId = type.Id
            };
            _robotRepository.Update(robotToUpdate);
            return new ServiceResponse
            {
                Data = true,
                Message = "Updated Successfully",
                Status = (int)ResponseStatusEnum.Success
            };
        }

        public ServiceResponse Delete(DeleteRobotRequest request)
        {
            int robotId = int.Parse(_protector.Unprotect(request.RobotId));
            var deleted = _robotRepository.DeleteById(robotId);
            if (deleted)
            {
                return new ServiceResponse
                {
                    Data = true,
                    Message = "Deleted Successfully",
                    Status = (int)ResponseStatusEnum.Success
                };
            }
            return new ServiceResponse
            {
                Data = false,
                Message = "Robot Not Exist!",
                Status = (int)ResponseStatusEnum.Failer
            };
        }

    }
}
