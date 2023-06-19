using APT_Storage.DataAccess.DTOs;
using APT_Storage.DataAccess.Repository.Contracts;
using APT_Storage.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APT_Storage.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;
        public UserController(IUserRepository user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO newUser)
        {
            try
            {
                if(newUser == null)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable);
                }
                else
                {
                    var mapUserDTO = _mapper.Map<User>(newUser);
                    await _user.CreateUserAsync(mapUserDTO);

                    var user = _mapper.Map<UserGetDTO>(mapUserDTO);
                    return Ok(user);
                }
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserByID(int userId)
        {
            try
            {
                var checkUser = await _user.GetUserById(userId);
                if(checkUser == null)
                {
                    return NotFound($"User with id {userId} doesn't exist");
                }
                else
                {
                    var user = _mapper.Map<UserGetDTO>(checkUser);
                    return Ok(user);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var checkUsers = await _user.GetAllUsers();
                var users = _mapper.Map<List<UserGetDTO>>(checkUsers);
                return Ok(users);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser ([FromBody]UserCreateDTO userToUpdate, int userId)
        {
            try
            {
                var userDetails = _mapper.Map<User>(userToUpdate);
                userDetails.Id = userId;
                if(userDetails == null)
                {
                    return NotFound("User doesn't exist");

                }
                else
                {
                    await _user.UpdateUserAsync(userDetails);
                    var updatedUser = _mapper.Map<UserGetDTO>(userDetails);
                    return CreatedAtAction(nameof(GetUserByID), new { userId = userDetails.Id }, updatedUser);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var checkUser = await _user.GetUserById(userId);
                if (checkUser == null)
                {
                    return NotFound("User Doesn't Exist");
                }
                else
                {
                    await _user.DeleteUserAsync(userId);
                    return Ok("Succefully deleted the User");
                }
                
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }


    
}
