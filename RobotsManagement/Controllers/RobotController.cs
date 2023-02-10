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
    public class RobotController : ControllerBase
    {
        private readonly IRobotService _robotService;
        public RobotController(IRobotService robotService)
        {
            _robotService = robotService;
        }

        [HttpGet]
        public ActionResult<ApiResponse> GetAllRobots()
        {
            try
            {
                var res = _robotService.GetAll();
                return new ApiResponse
                {
                    Data = res.Data,
                    Status = res.Status
                };
            }
            catch(Exception ex)
            {
                return new ApiResponse
                {
                    Status = (int)ApiStatusEnum.Exception,
                    ApiMessage = ex.Message
                };
            }
        }

        [HttpPost("GetRobotsByUserId")]
        public ActionResult<ApiResponse> GetRobotsByUserId(GetRobotsByUserIdRequest request)
        {
            try
            {
                var res = _robotService.GetByUserId(request);
                return new ApiResponse
                {
                    Data = res.Data,
                    Status = res.Status
                };
            }
            catch(Exception ex)
            {
                return new ApiResponse
                {
                    Status = (int)ApiStatusEnum.Exception,
                    ApiMessage = ex.Message
                };
            }
        }

        [HttpPost("Types")]
        public ActionResult<ApiResponse> GetRobotTypes()
        {
            try
            {
                var res = _robotService.GetRobotTypes();
                return new ApiResponse
                {
                    Data = res.Data,
                    Status = res.Status
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Status = (int)ApiStatusEnum.Exception,
                    ApiMessage = ex.Message
                };
            }
        }

        [HttpPost("Add")]
        public ActionResult<ApiResponse> AddRobot(AddRobotRequest request)
        {
            try
            {
                var res = _robotService.Add(request);
                return new ApiResponse
                {
                    Data = res.Data,
                    Status = res.Status,
                    ApiMessage = res.Message
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Status = (int)ApiStatusEnum.Exception,
                    ApiMessage = ex.Message
                };
            }
        }

        [HttpPost("Update")]
        public ActionResult<ApiResponse> Update(UpdateRobotRequest request)
        {
            try
            {
                var res = _robotService.Update(request);
                return new ApiResponse
                {
                    Data = res.Data,
                    Status = res.Status,
                    ApiMessage = res.Message
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Status = (int)ApiStatusEnum.Exception,
                    ApiMessage = ex.Message
                };
            }
        }

        [HttpPost("Delete")]
        public ActionResult<ApiResponse> Delete(DeleteRobotRequest request)
        {
            try
            {
                var res = _robotService.Delete(request);
                return new ApiResponse
                {
                    Data = res.Data,
                    Status = res.Status,
                    ApiMessage = res.Message
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Status = (int)ApiStatusEnum.Exception,
                    ApiMessage = ex.Message
                };
            }
        }
    }
}
