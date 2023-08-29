using Core_CollegeGrievanceCell.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_CollegeGrievanceCell.Controllers
{
    public class HODController : Controller
    {

        private readonly IHttpContextAccessor _Accessor;
        private readonly CollegeDbContext _context;
        public HODController(CollegeDbContext context, IHttpContextAccessor accessor)
        {

            _context = context;
            _Accessor = accessor;

        }
        public IActionResult HODModule()
        {
            return View();
        }
        public IActionResult DisplayAllComplaints()
        {

            var id = _Accessor.HttpContext.Session.GetInt32("id");

            var hod = _context.Users.FirstOrDefault(c => c.UserId == id);
          var dept =  hod.Department;

          var allcomplaints=  _context.Complaints.Where(c => c.Dept == dept).ToList();
            if(allcomplaints.Count==0)
            {
                ViewBag.Result = "No Complaints Yet";
            }

          return View(allcomplaints);

        }
        public IActionResult SolveComplaint()
        {
            var id = _Accessor.HttpContext.Session.GetInt32("id");

            var hod = _context.Users.FirstOrDefault(c => c.UserId == id);
            var dept = hod.Department;

            var allcomplaints = _context.Complaints.Where(c => c.Dept == dept&&c.Status=="Pending").ToList();
            if (allcomplaints.Count == 0)
            {
                ViewBag.Result = "No Complaints Yet";
            }

            return View(allcomplaints);


        }
        [HttpPost]
        public IActionResult SolveComplaint(int id)
        {




            var c = _context.Complaints.FirstOrDefault(c => c.ComplaintId == id);
            c.Status = "Solved";
            _context.Complaints.Update(c);

            int i = _context.SaveChanges();

            return RedirectToAction("SolveComplaint");

            
        }
        public IActionResult DisplaySolved()
        {
            var id = _Accessor.HttpContext.Session.GetInt32("id");

            var hod = _context.Users.FirstOrDefault(c => c.UserId == id);
            var dept = hod.Department;

            var allcomplaints = _context.Complaints.Where(c => c.Dept == dept && c.Status == "Solved").ToList();
            if (allcomplaints.Count == 0)
            {
                ViewBag.Result = "No Complaints Yet";
            }

            return View(allcomplaints);
        }

        }
    }
