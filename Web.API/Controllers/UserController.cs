using Business.Abstract;
using Core.Utilities.Results;
using DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace Web.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("User Controller");
        }

        
        [HttpGet]
        public IActionResult GetUsers(int index,int size)
        {
            var result = _userService.GetUsers(index,size);
            if (result.Success)
            {
                return ResponseHelper.CreateSuccesResponse(result.Data);
            }
            return ResponseHelper.CreateFailResponse(result.Message);
        }
    }
}
