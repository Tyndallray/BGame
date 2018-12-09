using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BGame.Models.UserModels;

namespace BGame.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IUser UserRep;
        public AccountController(UserManager<User> userMgr,
        SignInManager<User> signInMgr, IUser userRep)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            UserRep = userRep;
        }
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new User
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User loginUser)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(loginUser.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    loginUser.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid name or password");
            return View();
        }
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        public IActionResult Register()
        {
            return View();
        }
        // doesnt work
        //public RedirectResult RegisterAndLogin(string returnUrl="/") {
            
        //    return Redirect(returnUrl);
        //}
        [HttpPost]
        public async Task<IActionResult> RegisterAndLogin(User registerUser)
        {
            registerUser.ReturnUrl = registerUser.ReturnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new User { UserName = registerUser.UserName, Email = registerUser.Email, UserID = UserRep.GetUsers()+1 };
                var result = await userManager.CreateAsync(user, registerUser.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user,"Gen");
                    //this part is mainly for preparing email varifying callback 
                    //_logger.LogInformation("User created a new account with password.");
                    //var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Admin/Index",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);
                    //await .SendEmailAsync(registerUser.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(registerUser?.ReturnUrl ?? "/Admin/Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Invalid input");
            return View("Register");
        }
        //[HttpGet]
        //public async Task<User> GetCurUser(string pName)
        //{
        //  return await userManager.FindByNameAsync(pName);
        //}
    }
}

