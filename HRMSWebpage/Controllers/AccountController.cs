using HRMSWebpage.Common;
using HRMSWebpage.Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSWebpage.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> SignInPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignInPage(SignInViewModel model)
        {
            if(ModelState.IsValid)
            {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("LandingPage", "HRMS");
                    }
                
                ModelState.AddModelError(string.Empty,ConstantsInThisProject.InvalidLogin);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignOutPage()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignInPage");
        }
    }
}
