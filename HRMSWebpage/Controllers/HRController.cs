using HRMSWebpage.Entity.Models;
using HRMSWebpage.Service.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMSWebpage.Controllers
{
    public class HRController : Controller
    {
        private readonly IHRMSRepository _repository;

        public HRController(IHRMSRepository repository)
        {
            _repository = repository;
        }

        // Leave

        [HttpGet]
        public JsonResult ListLeavesDataTable()
        {
            var leaveDetails = _repository.GetEmployeeLeaveView();
            return Json(new { data = leaveDetails });
        }

        public IActionResult LeaveRequestApprover()
        {
            return View();
        }

        public IActionResult ApproveLeaveAppById(int id)
        {
            var leaveapp = _repository.LeaveDetailsById(id);
            leaveapp.Status = "Approved";
            _repository.ApproveLeaveAppById(leaveapp);
            return RedirectToAction("LeaveRequestApprover");
        }

        public IActionResult RejectLeaveAppById(int id)
        {
            var leaveapp = _repository.LeaveDetailsById(id);
            leaveapp.Status = "Rejected";
            _repository.ApproveLeaveAppById(leaveapp);
            return RedirectToAction("LeaveRequestApprover");
        }


        // Training


        /// <summary>
        [HttpGet]
        public JsonResult ListTrainingDataTable()
        {
            var TrainingDetails = _repository.GetTrainingView();
            return Json(new { data = TrainingDetails });
        }
        /// </summary>


        public IActionResult TrainingRequestApprover()
        {
            return View();
        }
        public IActionResult ApproveTrainingAppById(int id)
        {
            var trainingapp = _repository.GetTrainingFullDetailsById(id);
            trainingapp.Status = "Approved";
            _repository.ApproveTrainingAppById(trainingapp);
            return RedirectToAction("TrainingRequestApprover");
        }

        public IActionResult RejectTrainingAppById(int id)
        {
            var trainingapp = _repository.GetTrainingFullDetailsById(id);
            trainingapp.Status = "Rejected";
            _repository.ApproveTrainingAppById(trainingapp);
            return RedirectToAction("TrainingRequestApprover");
        }
        public IActionResult DoneTrainingAppById(int id)
        {
            var trainingapp = _repository.GetTrainingFullDetailsById(id);
            trainingapp.Status = "Done";
            _repository.ApproveTrainingAppById(trainingapp);
            return RedirectToAction("TrainingRequestApprover");
        }
        public IActionResult RemoveTrainingAppById(int id)
        {
            var trainingapp = _repository.GetTrainingFullDetailsById(id);
            trainingapp.Status = "Removed";
            _repository.ApproveTrainingAppById(trainingapp);
            return RedirectToAction("TrainingRequestApprover");
        }

        // Projects
        public IActionResult ProjectRequestApprover()
        {
            var result = _repository.GetAllEmployees();
            ViewBag.Employee = new SelectList(result, "EmpId", "FirstName");
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ListProjectDataTable()
        {
            var ProjectDetails = await _repository.GetAllProjects();
            return Json(new { data = ProjectDetails });
        }

        public JsonResult AddProjectApp(int prjtId, string empId, string startDate, string endDate)
        {
            ProjectApplication projApp = new ProjectApplication()
            {
                EmpId = empId,
                PrjtId = prjtId,
                ProjectStatus = "Ongoing",
                StartTime = DateTime.Parse(startDate),
                EndTime= DateTime.Parse(endDate)
            };
            _repository.AddProjectApp(projApp);
            return Json(true);
        }
        public JsonResult EditProjectApp(string empId, int prjtId)
        {
            var projectapp = _repository.GetProjectFullDetailsByIds(empId, prjtId);
            projectapp.ProjectStatus = "Relieved";
            _repository.UpdateProjectApp(projectapp);
            return Json(true);
        }
    }
}
