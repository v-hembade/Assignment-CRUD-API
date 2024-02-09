using JwtRoleBase.Interfaces;
using JwtRoleBase.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtRoleBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetUsersDetails();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(string employeeId)
        {
            try
            {
                var user = await _userService.GetUser(employeeId);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser([FromBody] Users user)
        {
            if (ModelState.IsValid)
            {
                var u = await _userService.AddUser(user);
                return StatusCode(201, u);
            }
            else
            {
                return BadRequest("request body does not contain required fields");
            }

        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var student = await _userService.DeleteUser(id);
                return StatusCode(204, student);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser([FromRoute] string id, [FromBody] Users user)
        {
            try
            {
                
                 var updatedUser = await _userService.UpdateUser(id, user);

                 if (updatedUser == null)
                        return NotFound();

                 return Ok(updatedUser);
                
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }

        

        
    }
}
