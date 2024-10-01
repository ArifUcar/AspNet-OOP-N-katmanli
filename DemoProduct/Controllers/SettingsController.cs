using DemoProduct.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoProduct.Controllers
{
    public class SettingsController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SettingsController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
           _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.Gender = values.Gender;
            userEditViewModel.Mail = values.Email;
            userEditViewModel.userName = values.UserName;
            
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.Email = p.Mail;
            user.Gender = p.Gender;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Login");
                
                    }
            else {

                //hata mesajları

            }
            return View(result);
        }
  

        

        }
    }

