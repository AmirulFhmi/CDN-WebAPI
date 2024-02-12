using CDN_Web.DataServices;
using CDN_Web.Models;
using Microsoft.AspNetCore.Mvc;
using static CDN_Web.Helper.APIHelper.URLs;

namespace CDN_Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IDataServices _dataServices;
        public UserController(IDataServices dataServices)
        {
            _dataServices = dataServices;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _dataServices.GetAllUsers();


            var model = new UserViewModel()
            {
                Users = data
            };

            return View(model);
        }

        public IActionResult CreateUser()
        {
            var model = new UserModel();

            return View(model);
        }
        public async Task<IActionResult> SubmitCreateUser(UserModel user)
        {
            try
            {
                var status = await _dataServices.CreateUser(user);

                if (status)
                    return RedirectToAction("Index"); ;

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> UpdateUser(int userId)
        {
            var data = await _dataServices.GetUser(userId);

            return View(data);
        }

        public async Task<IActionResult> SubmitUpdateUser(UserModel user)
        {
            try
            {
                var status = await _dataServices.UpdateUser(user);

                if (status)
                    return RedirectToAction("Index");

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var status = await _dataServices.DeleteUser(userId);

                if (status)
                    return RedirectToAction("Index"); ;

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
