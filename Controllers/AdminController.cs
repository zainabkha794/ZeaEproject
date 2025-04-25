using changes_project.Models;
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

       
        public async Task<IActionResult> Edit_batch(int id)
        {
            var BData = await _context.Batches.FindAsync(id);
            return View(BData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit_batch(int id, Batch obj)
        {
            _context.Batches.Update(obj);
            _context.SaveChanges();
            TempData["success"] = "Dr Updated Successfully";
            return Redirect("/Admin/All_batch");
        }

        public async Task<IActionResult> dlt_batch(int id)
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
                    var BData = await _context.Batches.FindAsync(id);
                    if (BData != null)
                    {
                        _context.Batches.Remove(BData);
                        _context.SaveChanges();
                        TempData["success"] = "Dr Deleted Successfully";
                        return Redirect("/Admin/All_batch");
                    }

                }
            }
            return RedirectToAction("login", "Account");
        }


        public async Task<IActionResult> dlt_faculty(int id)
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
                    var fData = await _context.Faculties.FindAsync(id);
                    if (fData != null)
                    {
                        _context.Faculties.Remove(fData);
                        _context.SaveChanges();
                        TempData["success"] = "Dr Deleted Successfully";
                        return Redirect("/Admin/All_faculty");
                    }

                }
            }
            return RedirectToAction("login", "Account");
        }


        public async Task<IActionResult> Edit_faculty(int id)
        {
            var fData = await _context.Faculties.FindAsync(id);
            return View(fData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit_faculty(int id, Faculty obj)
        {
            _context.Faculties.Update(obj);
            _context.SaveChanges();
            TempData["success"] = "Dr Updated Successfully";
            return Redirect("/Admin/All_faculty");
        }

        public async Task<IActionResult> dlt_student(int id)
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
                    var SData = await _context.Students.FindAsync(id);
                    if (SData != null)
                    {
                        _context.Students.Remove(SData);
                        _context.SaveChanges();
                        TempData["success"] = "Dr Deleted Successfully";
                        return Redirect("/Admin/all_students");
                    }

                }
            }
            return RedirectToAction("login", "Account");
        }


        public async Task<IActionResult> Edit_student(int id)
        {
            var SData = await _context.Students.FindAsync(id);
            return View(SData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit_student(int id, Student obj)
        {
            _context.Students.Update(obj);
            _context.SaveChanges();
            TempData["success"] = "Dr Updated Successfully";
            return Redirect("/Admin/all_students");
        }
        public async Task<IActionResult> course()
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
        public async Task<IActionResult> course(Course obj)
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

                    _context.Course.Add(obj);
                    _context.SaveChanges();
                    return RedirectToAction("course", "Admin");
                }
            }
            return RedirectToAction("login", "Account");
        }
        public async Task<IActionResult> All_courses()
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
                    var abData = _context.Courses.ToList();
                    return View(abData);
                }
            }
            return RedirectToAction("login", "Account");
        }



    }
}


  



   