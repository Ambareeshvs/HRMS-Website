using HRMSWebpage.Entity.Models;
using HRMSWebpage.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMSWebpage.Controllers
{
    public class HRMSController : Controller
    {
        private readonly IHRMSRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public HRMSController(IHRMSRepository repository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public IActionResult LandingPage()
        {
            var UserEmail = User.Identity.Name;
            var user = _repository.GetFullDetailsOfEmployeeByEmail(UserEmail);
            var actualLeaveDaysA = _repository.GetLeavesById(1);
            var alreadyAllottedLeavesA = _repository.GetLeavesAllotted(user.EmpId, 1);
            var AnnualLeaves = actualLeaveDaysA - alreadyAllottedLeavesA;

            var actualLeaveDaysC = _repository.GetLeavesById(3);
            var alreadyAllottedLeavesC = _repository.GetLeavesAllotted(user.EmpId, 3);
            var CasualLeaves = actualLeaveDaysC - alreadyAllottedLeavesC;

            var actualLeaveDaysS = _repository.GetLeavesById(4);
            var alreadyAllottedLeavesS = _repository.GetLeavesAllotted(user.EmpId, 4);
            var SickLeaves = actualLeaveDaysS - alreadyAllottedLeavesS;

            var actualLeaveDaysU = _repository.GetLeavesById(5);
            var alreadyAllottedLeavesU = _repository.GetLeavesAllotted(user.EmpId, 5);
            var UnpaidLeaves = actualLeaveDaysU - alreadyAllottedLeavesU;

            ViewBag.CasualLeave = CasualLeaves;
            ViewBag.AnnualLeave = AnnualLeaves;
            ViewBag.SickLeave = SickLeaves;
            ViewBag.UnpaidLeave = UnpaidLeaves;

            return View();
        }

        // Employee
        [AllowAnonymous]
        public IActionResult SearchEmployee(string EmpName)
        {
            var query = _repository.SearchEmployee().AsQueryable();
            if (!string.IsNullOrWhiteSpace(EmpName))
            {
                query = query.Where(emp => emp.FirstName.Contains(EmpName,StringComparison.CurrentCultureIgnoreCase));
            }
            return View(query.ToList());
        }


        // Leaves

        [HttpGet]
        public IActionResult LeaveTracker()
        {
            var leaves = _repository.GetAllLeavesName();
            ViewBag.Leaves = new SelectList(leaves, "LeaveId", "LeaveName");
            return View();
        }

        [HttpGet]
        public JsonResult ListLeavesDataTable()
        {
            var UserEmail = User.Identity.Name;
            var leaveDetails = _repository.GetEmployeeLeaveView(UserEmail);
            return Json(new { data = leaveDetails });
        }

        [HttpPost]
        public JsonResult LeaveTracker(string startDate, string endDate, int days, string description, int leaveId)
        {
            var UserEmail = User.Identity.Name;
            var result = _repository.GetFullDetailsOfEmployeeByEmail(UserEmail);
            LeaveApplication model = new LeaveApplication()
            {
                Days = days,
                Description = description,
                EmpId = result.EmpId,
                EndDate = DateTime.Parse(endDate),
                StartDate = DateTime.Parse(startDate),
                LeaveId = leaveId,
                Status = "Pending"
            };
            _repository.AddLeaveApplicationDetails(model);
            return Json(true);
        }

        public JsonResult LeavesRemaining(int leaveId, int requestedDays)
        {
            var UserEmail = User.Identity.Name;
            var user = _repository.GetFullDetailsOfEmployeeByEmail(UserEmail);
            var actualLeaveDays = _repository.GetLeavesById(leaveId);
            var alreadyAllottedLeaves = _repository.GetLeavesAllotted(user.EmpId, leaveId);
            var remaining = actualLeaveDays - alreadyAllottedLeaves;
            
            if (remaining >= requestedDays)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public JsonResult DltLeaveAppById(int Id)
        {
            _repository.DeleteLeaveAppById(Id);
            return Json(true);
        }

        // Training
        [HttpGet]
        public IActionResult TrainingTracker()
        {
            var training = _repository.GetAllTrainingName();
            ViewBag.Trainings = new SelectList(training, "TrainingId", "TrainingName");
            return View();
        }

        [HttpGet]
        public JsonResult ListTrainingDataTable()
        {
            var UserEmail = User.Identity.Name;
            var TrainingDetails = _repository.GetTrainingView(UserEmail);
            return Json(new { data = TrainingDetails });
        }

        [HttpPost]
        public JsonResult TrainingTracker(string startDate, string endDate, string details, int trainingId)
        {
            var UserEmail = User.Identity.Name;
            var result = _repository.GetFullDetailsOfEmployeeByEmail(UserEmail);
            TrainingApplication model = new TrainingApplication()
            {
                EmpId = result.EmpId,
                EndDate = DateTime.Parse(endDate),
                StartDate = DateTime.Parse(startDate),
                Status = "Pending",
                TrainingId= trainingId,
                Description= details,                
            };
            _repository.AddTrainingApplicationDetails(model);
            return Json(true);
        }

        public JsonResult GetTrainingDetailsById(int Id)
        {
            var details = _repository.GetTrainingDetailsById(Id);
            return Json(details);
        }

        // Projects
        public IActionResult ProjectTracker()
        {
            var UserEmail = User.Identity.Name;
            var result = _repository.GetFullDetailsOfEmployeeByEmail(UserEmail);
            var model = _repository.ProjectAssignedToUser(result.EmpId);
            return View(model);
        }
    }
}
