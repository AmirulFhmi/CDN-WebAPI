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
    public class HobbyController : Controller
    {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IMapper _mapper;

        public HobbyController(IHobbyRepository hobbyRepository, IMapper mapper)
        {
            _hobbyRepository = hobbyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HobbyModel>))]
        public IActionResult GetHobbies(int userId)
        {
            var hobbies = _mapper.Map<List<HobbyDto>>(_hobbyRepository.GetHobbies(userId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(hobbies);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateHobby([FromBody] HobbyDto hobby)
        {
            if (hobby == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hobbyMap = _mapper.Map<HobbyModel>(hobby);

            if (!_hobbyRepository.CreateHobby(hobbyMap))
            {
                ModelState.AddModelError("", "Failed to save hobby!");
                return StatusCode(505, ModelState);
            }

            return Ok("Hobby saved successfully!");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateHobby([FromBody] HobbyDto hobby)
        {
            if (hobby == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hobbyMap = _mapper.Map<HobbyModel>(hobby);

            if (!_hobbyRepository.UpdateHobby(hobbyMap))
            {
                ModelState.AddModelError("", "Failed to update user!");
                return StatusCode(505, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("DeleteHobby/{hobbyId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteHobby(int hobbyId)
        {
            if (hobbyId == 0)
            {
                return BadRequest();
            }

            var hobby = _hobbyRepository.GetHobby(hobbyId);

            var hobbyMap = _mapper.Map<HobbyModel>(hobby);

            if (!_hobbyRepository.DeleteHobby(hobbyMap))
            {
                ModelState.AddModelError("", "Failed to delete hobby!");
                return StatusCode(505, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("DeleteAllHobbies/{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAllHobbies(int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }

            if (!_hobbyRepository.DeleteAllHobbies(userId))
            {
                ModelState.AddModelError("", "Failed to delete hobbies!");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }
    }
}
