using CDN_Web.DataServices;
using CDN_Web.Models;
using Microsoft.AspNetCore.Mvc;
using static CDN_Web.Helper.APIHelper.URLs;

namespace CDN_Web.Controllers
{
    public class HobbyController : Controller
    {
        private readonly IDataServices _dataServices;
        public HobbyController(IDataServices dataServices)
        {
            _dataServices = dataServices;
        }

        public async Task<IActionResult> Index(int userId)
        {
            var data = await _dataServices.GetAllHobbies(userId);


            var model = new HobbyViewModel()
            {
                Hobbies = data,
                UserId = userId
            };

            return View(model);
        }

        public IActionResult CreateHobby(int userId)
        {
            var model = new HobbyModel()
            {
                UserId = userId
            };

            return View(model);
        }
        public async Task<IActionResult> SubmitCreateHobby(HobbyModel hobbyData)
        {
            try
            {
                var status = await _dataServices.CreateHobby(hobbyData);

                if (status)
                    return RedirectToAction("Index", new { userId = hobbyData.UserId }); ;

                return RedirectToAction("Index", new { userId = hobbyData.UserId }); ;
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { userId = hobbyData.UserId }); ;
            }

        }

        public async Task<IActionResult> UpdateHobby(int hobbyId)
        {
            var data = await _dataServices.GetHobby(hobbyId);

            return View(data);
        }

        public async Task<IActionResult> SubmitUpdateHobby(HobbyModel hobbyData)
        {
            try
            {
                var status = await _dataServices.UpdateHobby(hobbyData);

                if (status)
                    return RedirectToAction("Index", new { userId = hobbyData.UserId }); ;

                return RedirectToAction("Index", new { userId = hobbyData.UserId }); ;
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { userId = hobbyData.UserId }); ;
            }
        }

        public async Task<IActionResult> DeleteAllHobbies(int userId)
        {
            try
            {
                var status = await _dataServices.DeleteAllHobbies(userId);

                if (status)
                    return RedirectToAction("Index", new { userId }); ;

                return RedirectToAction("Index", new { userId }); ;

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { userId }); ;
            }
        }

        public async Task<IActionResult> DeleteHobby(int hobbyId, int userId)
        {
            try
            {
                var status = await _dataServices.DeleteHobby(hobbyId);

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
