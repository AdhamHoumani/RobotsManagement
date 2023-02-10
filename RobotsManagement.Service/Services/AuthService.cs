using AutoMapper;
using RobotsManagement.Data.Contracts;
using RobotsManagement.Data.Repository.Models;
using RobotsManagement.Service.Enum;
using RobotsManagement.Service.Interfaces;
using RobotsManagement.Service.Models.DTO;
using RobotsManagement.Service.Models.Mapping;
using RobotsManagement.Service.Models.Request;
using RobotsManagement.Service.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsManagement.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ServiceResponse Login(LoginRequest request) 
        {
            var user = _userRepository.GetUserByEmail(request.UserName);
            if(user == null)
            {
                return new ServiceResponse
                {
                    Message = "Username not exist!",
                    Status = (int)ResponseStatusEnum.Failer
                };
            }
            if(user.Password != request.Password)
            {
                return new ServiceResponse
                {
                    Message = "Invalid username or password!",
                    Status = (int)ResponseStatusEnum.Failer
                };
            }
            var userDto = _mapper.Map<UserDTO>(user);
            return new ServiceResponse
            {
                Data = userDto,
                Status = (int)ResponseStatusEnum.Success,
            };
        }
    }
}
