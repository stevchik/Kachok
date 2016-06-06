using Kachok.Model;
using Kachok.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kachok.Controllers.Web
{
    public class AuthController : Controller
    {
        private SignInManager<KachokUser> _signInManager;

        public AuthController(SignInManager<KachokUser> signInManager)
        {
            this._signInManager = signInManager;
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Site");
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, true, false);

                if(signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Index", "Site");
                    }
                    else
                    {
                        return RedirectToAction(returnUrl);
                    }
                }else
                {
                    ModelState.AddModelError("", "Usernamne or password incorrect");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Site");
        }

    }
}
