using HRMSWebpage.Entity.Models;
using HRMSWebpage.Entity.ViewModels;
using HRMSWebpage.Service.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMSWebpage.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHRMSRepository _repository;

        public EmployeeController(IHRMSRepository repository)
        {
            _repository = repository;
        }
        public IActionResult ProfilePage(string id)
        {
            var result = _repository.GetFullDetailsOfEmployeeByEmail(id);
            return View(result);
        }


        public async Task<JsonResult> EditEmpDetailsByEmp(string EmpID, string LastName, string PhoneNo, string Address)
        {
            _repository.EditEmpDetailsByEmp(EmpID, LastName, PhoneNo, Address);
            return Json(true);
        }
    }
}
