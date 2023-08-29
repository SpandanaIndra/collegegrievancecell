using Core_CollegeGrievanceCell.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Core_CollegeGrievanceCell.Controllers
{
    public class CollegeController : Controller
    {
        private readonly CollegeDbContext _context;
        private readonly IHttpContextAccessor _Accessor;

        public CollegeController(CollegeDbContext context, IHttpContextAccessor accessor)
        {

            _context = context;
            _Accessor = accessor;

        }
        public IActionResult Login()
        {
            var Dept = new List<Departments>
            {
        new Departments { DId = 1,DName = "Admin" },
        new Departments { DId = 2, DName = "Student" },
        new Departments { DId = 3, DName = "HOD" }
            };

            ViewBag.Dept = new SelectList(Dept, "DId", "DName");
            return View();
        }
        [HttpPost]
        public IActionResult Login(User u, string design)
        {

            int desig = Convert.ToInt32(u.Designation);
            if (desig == 1)
            {
                u.Designation = "Admin";
                var cust = _context.Admin.FirstOrDefault(c => c.AdminId == u.UserId && c.Password == u.Password && c.Designation == u.Designation);
                if (cust != null)
                {
                    _Accessor.HttpContext.Session.SetString("name", u.Designation);
                    return RedirectToAction("AdminModule", "Admin");
                }
                else
                {
                    ViewBag.msg = "Invalid Credentials..!!Try Again";
                    return View();
                }


            }

            else if (desig == 2)
            {
                u.Designation = "Student";
                var cust = _context.Users.FirstOrDefault(c => c.UserId == u.UserId && c.Password == u.Password && c.Designation == u.Designation);
                if (cust != null)
                {
                    //   ViewBag.name = u.Designation;
                    _Accessor.HttpContext.Session.SetInt32("id", u.UserId);

                    return RedirectToAction("StudentModule", "Student");
                }
                else
                {
                    ViewBag.msg = "Invalid Credentials..!!Try Again";
                    return View();
                }
            }
            else if (desig == 3)
            {
                u.Designation = "HOD";
                var cust = _context.Users.FirstOrDefault(c => c.UserId == u.UserId && c.Password == u.Password && c.Designation == u.Designation);
                if (cust != null)
                {
                    ViewBag.name = u.Designation;
                    _Accessor.HttpContext.Session.SetInt32("id", u.UserId);

                    return RedirectToAction("HODModule", "HOD");
                }
                else
                {
                    ViewBag.msg = "Invalid Credentials..!!Try Again";
                    return View();
                }
            }
            else
            {
                ViewBag.msg = "Please Select Designation..!!!";
            }


            return View();

        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User newuser)
        {
            try
            {
                _context.Users.Add(newuser);
                int res = _context.SaveChanges();
                ViewBag.Result = "Thanks For Registering..!";
               
            }
            catch(DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2627)
                {
                    ViewBag.Primary = "This Account is already Exists..!!";
                    // Handle primary key violation error
                    // (Error number 2627 indicates a unique constraint violation)
                }
               else if (ex.InnerException is SqlException sqlException1 && (sqlException1.Number == 547 || sqlException1.Number == 1452))
               {


                    ViewBag.Foreign = "Your Id is not enrolled by the Admin..Please Contact Admin For Furthur Information.";

        // Handle foreign key violation error
        // (Error number 547 or 1452 indicates a foreign key constraint violation)
                 }
                else
                {
                    ViewBag.msg = "Please give proper details..All Fields are Mandatory.";

                }



            }
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }


    }

}
