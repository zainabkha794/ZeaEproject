using Eproject.Areas.Identity.Data;
using Eproject.Data;
using Eproject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Eproject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly SignInManager<EprojectUser> _signInManager;
        private readonly UserManager<EprojectUser> _userManager;
        private readonly EprojectContext _context;
        public AdminController(SignInManager<EprojectUser> signInManager, UserManager<EprojectUser> userManager, EprojectContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.Role == "0")
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.Role == "1")
                {
                    return View();
                }
            }
            return RedirectToAction("login", "Account");
        }


        public async Task<IActionResult> add_batch()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.Role == "0")
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.Role == "1")
                {
                    return View();
                }
            }
            return RedirectToAction("login", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> add_batch(Batch obj)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.Role == "0")
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.Role == "1")
                {
                    _context.Batches.Add(obj);
                    _context.SaveChanges();
                    return RedirectToAction("add_batch", "Admin");
                }
            }
            return RedirectToAction("login", "Account");
        }

        public async Task<IActionResult> All_batch()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.Role == "0")
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.Role == "1")
                {
                    var abData = _context.Batches.ToList();
                    return View(abData);
                }
            }
            return RedirectToAction("login", "Account");
        }

        public async Task<IActionResult> add_faculty()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.Role == "0")
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.Role == "1")
                {
                    ViewBag.TimingOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "8:00 AM - 2:00 PM", Text = "8:00 AM - 2:00 PM" },
                new SelectListItem { Value = "3:00 PM - 7:00 PM", Text = "3:00 PM - 7:00 PM" },
                new SelectListItem { Value = "9:00 PM - 11:00 PM", Text = "9:00 PM - 11:00 PM" }
            };

                    return View();
                }
            }
            return RedirectToAction("login", "Account");
        }
        public async Task<IActionResult> all_faculty()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.Role == "0")
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.Role == "1")
                {
                    var dptData = _context.Faculties.ToList();
                    return View(dptData);
                }
            }
            return RedirectToAction("login", "Account");
        }



        [HttpPost]
        public async Task<IActionResult> add_faculty(Faculty obj)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.Role == "0")
                {
                    return RedirectToAction("Index", "User");
                }

                else if (user.Role == "1")
                {
                    _context.Faculties.Add(obj);
                    _context.SaveChanges();
                    return RedirectToAction("add_faculty", "Admin");
                }
                ViewBag.TimingOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "8:00 AM - 2:00 PM", Text = "8:00 AM - 2:00 PM" },
                new SelectListItem { Value = "3:00 PM - 7:00 PM", Text = "3:00 PM - 7:00 PM" },
                new SelectListItem { Value = "9:00 PM - 11:00 PM", Text = "9:00 PM - 11:00 PM" }
            };
                return View(obj);
            }
            return RedirectToAction("login", "Account");
        }

        public async Task<IActionResult> add_student()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.Role == "0")
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.Role == "1")
                {
                    var dpt = _context.Batches.ToList();
                    ViewBag.Batches = dpt;


                    return View();
                }
            }
            return RedirectToAction("login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> add_student(Student obj)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.Role == "0")
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.Role == "1")
                {
                    _context.Students.Add(obj);
                    _context.SaveChanges();
                    return RedirectToAction("add_student", "Admin");
                }
            }
            return RedirectToAction("login", "Account");
        }
        public async Task<IActionResult> all_students()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (user.Role == "0")
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.Role == "1")
                {
                    var studentData = _context.Students.ToList();
                    return View(studentData);
                }
            }
            return RedirectToAction("login", "Account");
        }

    }
}




   