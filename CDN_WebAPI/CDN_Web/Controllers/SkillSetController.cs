using CDN_Web.DataServices;
using CDN_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDN_Web.Controllers
{
    public class SkillSetController : Controller
    {
        private readonly IDataServices _dataServices;

        public SkillSetController(IDataServices dataServices)
        {
            _dataServices = dataServices;
        }
        public async Task<IActionResult> Index(int userId)
        {
            var data = await _dataServices.GetAllSkillSets(userId);

            var model = new SkillSetViewModel()
            {
                SkillSets = data,
                UserId = userId
            };

            return View(model);
        }

        public IActionResult CreateSkillSet(int userId)
        {
            var model = new SkillSetModel()
            {
                UserId = userId
            };

            return View(model);
        }
        public async Task<IActionResult> SubmitCreateSkillSet(SkillSetModel skillSetData)
        {
            try
            {
                var status = await _dataServices.CreateSkillSet(skillSetData);

                if (status)
                    return RedirectToAction("Index", new { userId = skillSetData.UserId }); ;

                return RedirectToAction("Index", new { userId = skillSetData.UserId }); ;
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { userId = skillSetData.UserId }); ;
            }

        }

        public async Task<IActionResult> UpdateSkillSet(int skillSetId)
        {
            var data = await _dataServices.GetSkillSet(skillSetId);

            return View(data);
        }

        public async Task<IActionResult> SubmitUpdateSkillSet(SkillSetModel skillSetData)
        {
            try
            {
                var status = await _dataServices.UpdateSkillSet(skillSetData);

                if (status)
                    return RedirectToAction("Index", new { userId = skillSetData.UserId }); ;

                return RedirectToAction("Index", new { userId = skillSetData.UserId }); ;
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { userId = skillSetData.UserId }); ;
            }
        }

        public async Task<IActionResult> DeleteAllSkillSets(int userId)
        {
            try
            {
                var status = await _dataServices.DeleteAllSkillSets(userId);

                if (status)
                    return RedirectToAction("Index", new { userId }); ;

                return RedirectToAction("Index", new { userId }); ;

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { userId }); ;
            }
        }

        public async Task<IActionResult> DeleteSkillSet(int skillSetId, int userId)
        {
            try
            {
                var status = await _dataServices.DeleteSkillSet(skillSetId);

                if (status)
                    return RedirectToAction("Index", new { userId }); ;

                return RedirectToAction("Index", new { userId }); ;

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { userId }); ;
            }
        }
    }
}
