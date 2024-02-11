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
    public class SkillSetController : Controller
    {
        private readonly ISkillSetRepository _skillSetRepository;
        private readonly IMapper _mapper;

        public SkillSetController(ISkillSetRepository skillSetRepository, IMapper mapper)
        {
            _skillSetRepository = skillSetRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SkillSetModel>))]
        public IActionResult GetSkillSets(int userId)
        {
            var skillsets = _mapper.Map<List<SkillSetDto>>(_skillSetRepository.GetSkillSets(userId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(skillsets);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSkillSet([FromBody] SkillSetDto skillset)
        {
            if (skillset == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skillsetMap = _mapper.Map<SkillSetModel>(skillset);

            if (!_skillSetRepository.CreateSkillSet(skillsetMap))
            {
                ModelState.AddModelError("", "Failed to save skillset!");
                return StatusCode(505, ModelState);
            }

            return Ok("Skillset successfully saved!");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateSkillSet([FromBody] SkillSetDto skillSet)
        {
            if (skillSet == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skillSetMap = _mapper.Map<SkillSetModel>(skillSet);

            if (!_skillSetRepository.UpdateSkillSet(skillSetMap))
            {
                ModelState.AddModelError("", "Failed to update user!");
                return StatusCode(505, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("DeleteSkillSet/{skillSetId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSkillSet(int skillSetId)
        {
            if (skillSetId == 0)
            {
                return BadRequest();
            }

            var skillSet = _skillSetRepository.GetSkillSet(skillSetId);

            var skillSetMap = _mapper.Map<SkillSetModel>(skillSet);

            if (!_skillSetRepository.DeleteSkillSet(skillSetMap))
            {
                ModelState.AddModelError("", "Failed to delete skillset!");
                return StatusCode(505, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("DeleteAllSkillSets/{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAllSkillSets(int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }

            if (!_skillSetRepository.DeleteAllSkillSets(userId))
            {
                ModelState.AddModelError("", "Failed to delete skillsets!");
                return StatusCode(505, ModelState);
            }
            return NoContent();
        }
    }
}
