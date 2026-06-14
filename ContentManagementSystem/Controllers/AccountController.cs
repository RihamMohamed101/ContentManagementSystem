using ContentManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signIn;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signIn)
        {
            _userManager = userManager;
            _signIn = signIn;
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDB = new IdentityUser()
                {
                    UserName = model.UserName
                   
                };

                var result = await _userManager.CreateAsync(userDB, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userDB, "Admin");
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);

        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user is not null)
                {
                    var flag = await _userManager.CheckPasswordAsync(user, model.Password);

                    if (flag)
                    {
                        var result = await _signIn.PasswordSignInAsync(user, model.Password , false , false);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }

                }

                ModelState.AddModelError(string.Empty, "Invalid Login");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction("Login");
        }

       
    }
}
