using Core_CollegeGrievanceCell.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_CollegeGrievanceCell.Controllers
{
   

    public class AdminController : Controller
    {
        private readonly IHttpContextAccessor _Accessor;
        private readonly CollegeDbContext _context;
        public AdminController(CollegeDbContext context, IHttpContextAccessor accessor)
        {

            _context = context;
            _Accessor = accessor;

        }
        public IActionResult AdminModule()
        {
            ViewBag.name = _Accessor.HttpContext.Session.GetString("name");

            return View();
        }

        public IActionResult AddOrDeleteStudent()
        {

          
            return View();
        }
        [HttpPost]
        public IActionResult AddOrDeleteStudent(DetailsByAdmin user, string add, string delete)
        {
            int id=user.Id;
            if (add != null)
            {

                try
                {
                    _context.UserDetailsByAdmin.Add(user);
                   int result= _context.SaveChanges();
                if(result == 1)
                    {
                        ViewBag.res = "Details Inserted Successfully..!";
                    }

                }
                catch (Exception ex)
                {
                    ViewBag.msg = "This Id is already exists..!!";
                }
            }
         if(delete != null) 
            {
              
                    _context.UserDetailsByAdmin.Remove(user);
                
                    var result = _context.SaveChanges();

                if (result == 1)
                    {
                 
                 
                        ViewBag.msg = "Deleted Successfully..!";

                    
                }
                
               
            }

            return View();
        }

        public IActionResult DisplayAll()
        {
            var list = _context.Complaints.ToList();
            return View(list);


            
        }
        public IActionResult SolveComplaint()
        {
            var pendingComplaints = _context.Complaints.Where(c=>c.Status=="Pending").ToList();
            if(pendingComplaints.Count==0)
            {
                ViewBag.complaints = "No Pending Complaints";

            }
            return View(pendingComplaints);



        }
        [HttpPost]
        public IActionResult SolveComplaint(int id)
        {
            
         var c=   _context.Complaints.FirstOrDefault(c=>c.ComplaintId==id);
            c.Status = "Solved";
           _context.Complaints.Update(c);

           int i = _context.SaveChanges();

            return RedirectToAction("SolveComplaint");
        }


        public IActionResult DisplaySolved()
        {
            var solvedComplaints = _context.Complaints.Where(c => c.Status == "Solved").ToList();
            if (solvedComplaints.Count == 0)
            {
                ViewBag.complaints = "No Pending Complaints";

            }
            return View(solvedComplaints);
           
        }


        }
    }
