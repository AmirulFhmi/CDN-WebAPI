using AutoMapper;
using CDN_WebAPI.Dto;
using CDN_WebAPI.Interfaces;
using CDN_WebAPI.Models;
using CDN_WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CDN_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetAllUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(ICollection<UserModel>))]
        public IActionResult GetUser(int userId)
        {
            if (!_userRepository.IsUserExists(userId))
                return NotFound();

            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest(ModelState);
            }

            var userModels = _userRepository.GetAllUsers()
                .Where(u => u.FirstName.Trim().ToUpper() == user.FirstName.Trim().ToUpper() &&
                u.LastName.Trim().ToUpper() == user.LastName.Trim().ToUpper())
                .FirstOrDefault();

            if (userModels != null)
            {
                ModelState.AddModelError("", "User already exists!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userMap = _mapper.Map<UserModel>(user);

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Failed to create users");
                return StatusCode(505, ModelState);
            }

            return Ok("User successfully created");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest(ModelState);
            }

            if (!_userRepository.IsUserExists(user.UserId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userMap = _mapper.Map<UserModel>(user);

            if (!_userRepository.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Failed to delete user!");
                return StatusCode(505, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }

            if (!_userRepository.IsUserExists(userId))
            {
                return NotFound();
            }

            var user = _userRepository.GetUser(userId);

            var userMap = _mapper.Map<UserModel>(user);

            if (!_userRepository.DeleteUser(userMap))
            {
                ModelState.AddModelError("", "Failed to delete hobby!");
                return StatusCode(505, ModelState);
            }

            return NoContent();
        }
    }
}
