using _51_MVC_Identity.Models;
using _51_MVC_Identity.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace _51_MVC_Identity.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            IQueryable users = _userManager.Users.Select(u => new ListUserVM
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            });
            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisteUserVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.Phone
                };
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,error.Description.ToString());
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if(appUser is not null)
            {
                EditUserVM model = new EditUserVM();
                model.Id = appUser.Id;
                model.UserName = appUser.UserName;
                model.FirstName = appUser.FirstName;
                model.LastName = appUser.LastName;
                model.Email = appUser.Email;
                model.Phone = appUser.PhoneNumber;
                return View(model);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByIdAsync(model.Id);
                if (appUser.UserName != model.UserName)
                    appUser.UserName = model.UserName;
                if (appUser.FirstName != model.FirstName)
                    appUser.FirstName = model.FirstName;
                if (appUser.LastName != model.LastName)
                    appUser.LastName = model.LastName;
                if (appUser.Email != model.Email)
                    appUser.Email = model.Email;
                if (appUser.PhoneNumber != model.Phone)
                    appUser.PhoneNumber = model.Phone;
                
                IdentityResult results = await _userManager.UpdateAsync(appUser);
                if (results.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                    return BadRequest();
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            IdentityResult results = await _userManager.DeleteAsync(user);
            if (results.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
                return BadRequest();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.Username);
            if (user is not null)
            {
                SignInResult results = await _signInManager.PasswordSignInAsync(user,model.Password,true,false);
                if (results.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (results.IsLockedOut)
                {
                    //kullanıcı hesabi kitlendiğinde
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Hatalı Giriş");
                }
            }
            else
            {
                ModelState.AddModelError("Kullanıcı bulunamadı", "Lütfen kayıt olunuz");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
