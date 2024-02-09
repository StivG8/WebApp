using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApp.Domain.Commons.Configurations;
using WebApp.Domain.Entities.Users;
using WebApp.Service.DTOs.Users;
using WebApp.Service.Interfaces;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class UserController:ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost, Authorize]
        public async ValueTask<IActionResult> CreateAsync(UserForCreationDTO userForCreationDTO)
            => Ok(await userService.CreateAsnyc(userForCreationDTO));

        [HttpGet("{id}"), AllowAnonymous]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await userService.GetAsync(u=>u.Id==id));

        [HttpGet, Authorize]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await userService.GetAllAsync(@params));

        [HttpDelete("{id}"), Authorize]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute]int id)
            => Ok(await userService.DeleteAsnyc(id));

        [HttpPut("{id}"), Authorize]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, UserForUpdateDTO userForUpdateDTO)
            => Ok(await userService.UpdateAsnyc(id, userForUpdateDTO));
    }
}
