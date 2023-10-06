using _52_MVC_IdentityRole.Context;
using _52_MVC_IdentityRole.Models;
using _52_MVC_IdentityRole.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace _52_MVC_IdentityRole.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            IQueryable users = _userManager.Users.Select(u => new ListUserVM
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email
            });
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterUserVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = model.UserName,
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
                        ModelState.AddModelError(string.Empty, error.Description.ToString());
                    }
                }
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVMs model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.Username);
            if (user is not null)
            {
                SignInResult results = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
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
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(IdentityRole model)
        {
            var role = new IdentityRole();
            role.Name = model.Name;
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult RoleList()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult RoleUpdate(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(c => c.Id == id);
            return View(role);
        }
        [HttpPost]
        public async Task<ActionResult> RoleUpdate(IdentityRole model)
        {
            IdentityRole role = new();
            role = _roleManager.Roles.FirstOrDefault(c => c.Id == model.Id);
            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }
            else
            {
                return View(role);
            }
        }
        public async Task<IActionResult> RoleDelete(string id)
        {
            IdentityRole role = new();
            role = _roleManager.Roles.FirstOrDefault(c => c.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }
            else
            {
                return View(role);
            }
        }
        public async Task<IActionResult> Details(string id)
        {
            UserRoleVM roleVM = new();
            roleVM.Id = id;

            roleVM.Roles = await _roleManager.Roles.ToListAsync();
            return View(roleVM);    
        }
        [HttpPost]
        public async Task<IActionResult> Details(UserRoleVM model)
        {
            AppUser user = await _userManager.FindByIdAsync(model.Id);
            var result = await _userManager.AddToRoleAsync(user, model.Name);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
