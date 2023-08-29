using Core_CollegeGrievanceCell.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Core_CollegeGrievanceCell.Controllers
{
    public class StudentController : Controller
    {
        private readonly CollegeDbContext _context;
        private readonly IHttpContextAccessor _Accessor;

        public StudentController(CollegeDbContext context, IHttpContextAccessor accessor)
        {

            _context = context;
            _Accessor = accessor;

        }
        public IActionResult StudentModule()
        {
            return View();
        }
        public IActionResult RaiseAComplaint()
        {
        
            
            return View();
        }
        [HttpPost]
        public IActionResult RaiseAComplaint(Complaint comp)
        {
            int id = Convert.ToInt32(_Accessor.HttpContext.Session.GetInt32("id"));
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            comp.UsersId = id;
            comp.Dept = user.Department;
            comp.DateOfComplaint=System.DateTime.Now;
            comp.Status = "Pending";
            _context.Complaints.Add(comp);
            int result=_context.SaveChanges();
            if(result==1)
            {
                ViewBag.result = comp.ComplaintId;
            }
            return View();
        }

        public IActionResult DisplayAll()
        {
            var id = _Accessor.HttpContext.Session.GetInt32("id");

            var list =_context.Complaints.Where(comp => comp.UsersId == id).ToList();
            return View(list);
        }

        public IActionResult DisplayPending(Complaint compl)
        {
            var id = _Accessor.HttpContext.Session.GetInt32("id");

            var pendingComplaints = _context.Complaints.Where(comp => comp.UsersId == id && comp.Status == "Pending").ToList();
            if (pendingComplaints.Count == 0)
            {
                ViewBag.msg = "No Pending Complaints";
                return View(pendingComplaints);
            }
            return View(pendingComplaints);
        }
        public IActionResult DisplaySolved()
        {
            var id = _Accessor.HttpContext.Session.GetInt32("id");

            var SolvedComplaints = _context.Complaints.Where(comp => comp.UsersId == id && comp.Status == "Solved").ToList();
            if(SolvedComplaints==null)
            {
                ViewBag.msg = "No Solved Complaints";
                return View(SolvedComplaints);  
            }

            return View(SolvedComplaints);
        }
    }
}
