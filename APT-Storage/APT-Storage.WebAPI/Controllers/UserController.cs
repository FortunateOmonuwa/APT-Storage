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
        private readonly ILogger<UserController> _logger;
        public UserController(IUserRepository user, IMapper mapper, ILogger<UserController> logger)
        {
            _user = user;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO newUser)
        {
            try
            {
                if(newUser == null)
                {
                    _logger.LogError("Error creating new user because newUser parameters are empty");
                    return StatusCode(StatusCodes.Status406NotAcceptable);
                }
  
                else
                {
                    var mapUserDTO = _mapper.Map<User>(newUser);
                    if(mapUserDTO.Username == null) 
                    {
                        _logger.LogError("Error creating new user because user already exists");
                        return StatusCode(StatusCodes.Status406NotAcceptable, $"user with username {mapUserDTO.Username}already exists");
                       
                    }
                    else if(mapUserDTO.Email != null)
                    {
                        _logger.LogError("Error creating new user because user already exists");
                        return StatusCode(StatusCodes.Status406NotAcceptable, $"user with Email {mapUserDTO.Email}already exists");
                    }
                    else
                    {
                        await _user.CreateUserAsync(mapUserDTO);

                        var user = _mapper.Map<UserGetDTO>(mapUserDTO);
                        _logger.LogInformation($"New user with details: Username - {user.Username}, FirstName - {user.FirstName}, LastName - {user.LastName}, Email - {user.Email}, was successfully created on {user.CreatedAt}");
                        return Ok(user);
                    }
                  
                }
            }
            catch(Exception ex) 
            {
                _logger.LogError("Error with server or code");
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
                    _logger.LogError($"{userId} not found.");
                    return NotFound($"User with id {userId} doesn't exist");
                }
                else
                {
                    var user = _mapper.Map<UserGetDTO>(checkUser);
                    _logger.LogInformation($"User with id {userId} and Username {user.Username} was successfully retrieved ");
                    return Ok(user);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error with server or code {ex.Message}", ex);
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
                _logger.LogError($"There was an error retrieving all the users from the database{ex.Message}", ex);
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
                    _logger.LogError($"user details were empty which led to an error updating user");
                    return NotFound("User doesn't exist");

                }
                else
                {
                    await _user.UpdateUserAsync(userDetails);
                    _logger.LogInformation($"The user {userDetails.Username} with id {userDetails.Id} was successfully updated");
                    var updatedUser = _mapper.Map<UserGetDTO>(userDetails);
                    return CreatedAtAction(nameof(GetUserByID), new { userId = userDetails.Id }, updatedUser);

                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Error with server or code base");
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
                    _logger.LogError("There was an error retrieving the user to be deleted because user doesn't exist");
                    return NotFound("User Doesn't Exist");
                }
                else
                {
                    await _user.DeleteUserAsync(userId);
                    _logger.LogInformation($"The user was successfully deleted");
                    return Ok("Succefully deleted the User");
                }
                
            }
            catch(Exception ex)
            {
                _logger.LogError("Error with server or code base");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }


    
}
