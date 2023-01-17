using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Pronia.Models;
using Pronia.ViewModels.User;

namespace Pronia.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> _userManager { get; }
        SignInManager<AppUser> _signInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser AppUser = await _userManager.FindByNameAsync(registerVM.Username);

            if (AppUser != null)
            {
                ModelState.AddModelError("Username", "Bu istifadeci artiq movcuddur.");
                return View();
            }

            AppUser appUser = new AppUser
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                UserName = registerVM.Username,
                Email = registerVM.email,
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(appUser, true);
            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = await _userManager.FindByNameAsync(loginVM.UsernameOrEmail);
            if (appUser is null)
            {
                appUser = await _userManager.FindByEmailAsync(loginVM.UsernameOrEmail);
                

                if (appUser is null)
                {
                    ModelState.AddModelError("", "Bele bir hesab yoxdur.");
                    return View();
                }
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.IsParsistance, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Bele bir hesab yoxdur.");
                return View();
            }

            return RedirectToAction(nameof(Index), "Home");
        }

    }
}
