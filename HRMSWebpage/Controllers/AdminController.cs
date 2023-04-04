using HRMSWebpage.Entity.Models;
using HRMSWebpage.Entity.ViewModels;
using HRMSWebpage.Service.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace HRMSWebpage.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHRMSRepository _repository;
        private readonly IWebHostEnvironment _env;
        private readonly IToastNotification _toastService;

        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, 
            RoleManager<IdentityRole> roleManager, IHRMSRepository repository, IWebHostEnvironment env,
            IToastNotification toastService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _repository = repository;
            _env = env;
            _toastService = toastService;
        }

        public SignInManager<IdentityUser> SignInManager { get; }

        // Admin SignUp Management

        [HttpGet]
        public async Task<IActionResult> SignUpPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpPage(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignInPage", "Account");
                }
            }
            return View();
        }

        //Admin User Management

        [HttpGet]
        public async Task<IActionResult> EditUserById(string Id)
        {
            ViewBag.Salaries = await _repository.GetAllSalary();
            ViewBag.Departments = await _repository.GetAllDepartments();
            ViewBag.Posts = await _repository.GetAllPositions();

            var user = await _userManager.FindByIdAsync(Id);
            var Email = user.Email;
            EmployeeViewModel model = new EmployeeViewModel()
            {
                EmpId = Id,
                Email = Email
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserById(EmployeeViewModel model)
        {
            Employee emp = new Employee()
            {
                EmpId = model.EmpId,
                ImgName = model.ImgName,
                Address = model.Address,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DOB = model.DOB,
                PhoneNumber = model.PhoneNumber,
                Sex = model.Sex,
                DeptId = model.DeptId,
                PositionId = model.PositionId,
                SalaryId = model.SalaryId
            };
            if (emp.ImgName != null)
            {
                string folderPath = Path.Combine(_env.WebRootPath, "Images");
                string filePath = Path.Combine(folderPath, emp.ImgName.FileName);
                emp.ImgName.CopyTo(new FileStream(filePath, FileMode.Create));
                emp.Image = emp.ImgName.FileName;
            }
            _repository.EditUserById(emp);
            return RedirectToAction(nameof(ListUsersUsers));
        }

        [HttpGet]
        public async Task<IActionResult> ListUsersUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpGet]
        public JsonResult ListUsersUsersDataTable()
        {
            var users = _userManager.Users;
            return Json(new { Data = users });
        }
        [HttpPost]
        public async Task<JsonResult> DeleteUserById(string Id)
        {
            _repository.DeleteUserById(Id);
            var user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return Json(true);
        }

        // Admin Role Management

        [HttpGet]
        public async Task<IActionResult> ListUsersRoles()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpGet]
        public JsonResult ListUsersDataTable()
        {
            var users = _userManager.Users;
            return Json(new { Data = users });
        }



        [HttpPost]
        public async Task<JsonResult> AddRoles(AddRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = model.RoleName
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return Json(true);
                }
            }
            return Json(false);
        }

        [HttpGet]
        public async Task<IActionResult> AddRemoveRoles(string id)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var user = await _userManager.FindByIdAsync(id);

            UserResults users = new UserResults()
            {
                Id = id,
                UserName = user.UserName
            };

            foreach (var role in roles)
            {
                AddRemoveViewModel rolemodel = new AddRemoveViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name)
                };
                users.AddRemove.Add(rolemodel);
            }
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddRemoveRoles(UserResults model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            IdentityResult result = new IdentityResult();
            bool bFlag = false;
            if (ModelState.IsValid)
            {
                for (int i = 0; i < model.AddRemove.Count; i++)
                {
                    if (model.AddRemove[i].IsSelected && !await _userManager.IsInRoleAsync(user, model.AddRemove[i].RoleName))
                    {
                        result = await _userManager.AddToRoleAsync(user, model.AddRemove[i].RoleName);
                        bFlag = true;
                    }
                    else if (!model.AddRemove[i].IsSelected && await _userManager.IsInRoleAsync(user, model.AddRemove[i].RoleName))
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.AddRemove[i].RoleName);
                        bFlag = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (bFlag)
                {
                    return RedirectToAction(nameof(ListUsersRoles));
                }
            }
            return View(result);
        }


        // Admin Department Management
        public async Task<IActionResult> ListAllDepartment()
        {
            var result = await _repository.GetAllDepartments();
            return View(result);
        }

        public JsonResult DltDeptById(int Id)
        {
            _repository.DeleteDeptById(Id);
            return Json(true);
        }

        public JsonResult EditDeptById(Department model)
        {
            _repository.EditDeptById(model);
            return Json(true);
        }

        public async Task<JsonResult> AddDept(string deptName)
        {
            var temp = await _repository.GetAllDepartments();
            if(temp.Where(x => x.DeptName == deptName).Count()!=0)
            {
                _toastService.AddWarningToastMessage("Department Already Exists!");
                return Json(false);
            }
            else
            {
                Department departments = new Department()
                {
                    DeptName = deptName
                };
                if (ModelState.IsValid)
                {
                    _repository.AddDept(departments);
                }
                return Json(true);
            }
            
        }



        // Admin Position Management
        public async Task<IActionResult> ListAllPosition()
        {

            var result = await _repository.GetAllPositions();
            return View(result);
        }

        public JsonResult DltPositionById(int Id)
        {
            _repository.DeletePositionById(Id);
            return Json(true);
        }

        public JsonResult EditPositionById(Position model)
        {
            _repository.EditPositionById(model);
            return Json(true);
        }

        public async Task<JsonResult> AddPosition(string positionName)
        {
            var temp = await _repository.GetAllPositions();
            if (temp.Where(x => x.PositionName == positionName).Count() != 0)
            {
                _toastService.AddWarningToastMessage("Position Already Exists!");
                return Json(false);
            }
            else
            {
                Position positions = new Position()
                {
                    PositionName = positionName
                };
                if (ModelState.IsValid)
                {
                    _repository.AddPosition(positions);
                }
                return Json(true);
            }
        }


        // Admin Salary Management
        public async Task<IActionResult> ListAllSalary()
        {
            var result = await _repository.GetAllSalary();
            return View(result);
        }

        public JsonResult DltSalaryById(int Id)
        {
            _repository.DeleteSalaryById(Id);
            return Json(true);
        }

        public JsonResult EditSalaryById(int SalaryId, string beneficiaries, string BasicPay, string pf)
        {
            Salary model = new Salary()
            {
                SalaryId = SalaryId,
                BasicPay = float.Parse(BasicPay),
                Beneficiaries = beneficiaries,
                ProvidentFund = float.Parse(pf)
            };
            _repository.EditSalaryById(model);
            return Json(true);
        }

        public JsonResult AddSalary(string beneficiaries, string BasicPay, string pf)
        {
            Salary salary = new Salary()
            {
                BasicPay = float.Parse(BasicPay),
                Beneficiaries = beneficiaries,
                ProvidentFund = float.Parse(pf)
            };
            if (ModelState.IsValid)
            {
                _repository.AddSalary(salary);
            }
            return Json(true);
        }


        // Admin Project Management
        public async Task<IActionResult> ListAllProjects()
        {
            var result = await _repository.GetAllProjects();
            return View(result);
        }

        public JsonResult DltProjectById(int Id)
        {
            _repository.DeleteProjectById(Id);
            return Json(true);
        }

        public JsonResult EditProjectById(Project model)
        {
            _repository.EditProjectById(model);
            return Json(true);
        }

        public JsonResult AddProject(string projectName, string projectDetails)
        {
            Project projects = new Project()
            {
                PrjtName = projectName,
                PrjtDescription = projectDetails
            };
            if (ModelState.IsValid)
            {
                _repository.AddProject(projects);
            }
            return Json(true);
        }


        // Admin Training Management
        public async Task<IActionResult> ListAllTrainings()
        {
            var result = await _repository.GetAllTraining();
            return View(result);
        }

        public JsonResult DltTrainingById(int Id)
        {
            _repository.DeleteTrainingById(Id);
            return Json(true);
        }

        public JsonResult EditTrainingById(Training model)
        {
            _repository.EditTrainingById(model);
            return Json(true);
        }

        public JsonResult AddTraining(string trainingName, string trainingDetails)
        {
            Training trainings = new Training()
            {
                TrainingName = trainingName,
                TrainingDetails = trainingDetails
            };
            if (ModelState.IsValid)
            {
                _repository.AddTraining(trainings);
            }
            return Json(true);
        }


        // Admin Leave Management
        public async Task<IActionResult> ListAllLeaves()
        {
            var result = await _repository.GetAllLeaves();
            return View(result);
        }

        public JsonResult DltLeavesById(int Id)
        {
            _repository.DeleteLeavesById(Id);
            return Json(true);
        }

        public JsonResult EditLeavesById(Leaves model)
        {
            _repository.EditLeavesById(model);
            return Json(true);
        }

        public JsonResult AddLeaves(string leaveName, int leaveDays)
        {
            Leaves leaves = new Leaves()
            {
                LeaveName = leaveName,
                LeaveDays = leaveDays
            };
            if (ModelState.IsValid)
            {
                _repository.AddLeaves(leaves);
            }
            return Json(true);
        }
    }
}
