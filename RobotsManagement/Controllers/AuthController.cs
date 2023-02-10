using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotsManagement.Enums;
using RobotsManagement.Models.Responses;
using RobotsManagement.Service.Interfaces;
using RobotsManagement.Service.Models.Request;

namespace RobotsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public ActionResult<ApiResponse> Login(LoginRequest request)
        {
            try
            {
                var res = _authService.Login(request);
                return new ApiResponse
                {
                    Data = res.Data,
                    ApiMessage = res.Message,
                    Status = res.Status
                };
            }
            catch(Exception ex)
            {
                return new ApiResponse
                {
                    ApiMessage = ex.Message,
                    Status = (int)ApiStatusEnum.Exception
                };
            }
        }
    }
}
