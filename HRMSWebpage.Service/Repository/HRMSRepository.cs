using HRMSWebpage.Entity.Data;
using HRMSWebpage.Entity.Models;
using HRMSWebpage.Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Service.Repository
{
    public class HRMSRepository : IHRMSRepository
    {
        private readonly ApplicationDbContext context;

        public HRMSRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        // Admin Department Management
        public async Task<List<Department>> GetAllDepartments()
        {
            var result = await context.Dept.ToListAsync();
            return result;
        }

        public void DeleteDeptById(int id)
        {
            var dataField = context.Dept.Find(id);
            context.Dept.Remove(dataField);
            context.SaveChanges();
        }

        public void EditDeptById(Department department)
        {
            context.Dept.Update(department);
            context.SaveChanges();
        }

        public void AddDept(Department department)
        {
            context.Dept.Add(department);
            context.SaveChanges();
        }


        // Admin Position Management
        public async Task<List<Position>> GetAllPositions()
        {
            var result = await context.Post.ToListAsync();
            return result;
        }

        public void DeletePositionById(int id)
        {
            var dataField = context.Post.Find(id);
            context.Post.Remove(dataField);
            context.SaveChanges();
        }

        public void EditPositionById(Position positions)
        {
            context.Post.Update(positions);
            context.SaveChanges();
        }

        public void AddPosition(Position positions)
        {
            context.Post.Add(positions);
            context.SaveChanges();
        }


        // Admin Salary Management
        public async Task<List<Salary>> GetAllSalary()
        {
            var result = await context.Sal.ToListAsync();

            //foreach(var item in result)
            //{
            //    if(item.SalaryDeleted == 0)
            //    {
            //        item.Status = "Active";
            //    }
            //    else
            //    {
            //        item.Status = "In-active";
            //    }
            //}

            return result;
        }

        public void DeleteSalaryById(int id)
        {
            var dataField = context.Sal.Find(id);
            context.Sal.Remove(dataField);
            context.SaveChanges();
        }

        public void EditSalaryById(Salary salary)
        {
            context.Sal.Update(salary);
            context.SaveChanges();
        }

        public void AddSalary(Salary salary)
        {
            context.Sal.Add(salary);
            context.SaveChanges();
        }

        // Admin User Management
        public void EditUserById(Employee employee)
        {
            context.Emp.Add(employee);
            context.SaveChanges();
        }

        public void DeleteUserById(string id)
        {
            var dataField = context.Emp.Find(id);
            context.Emp.Remove(dataField);
            context.SaveChanges();
        }

        // Admin Project Management
        public async Task<List<Project>> GetAllProjects()
        {
            var result = await context.Prjt.ToListAsync();
            return result;
        }

        public void DeleteProjectById(int id)
        {
            var dataField = context.Prjt.Find(id);
            context.Prjt.Remove(dataField);
            context.SaveChanges();
        }

        public void EditProjectById(Project projects)
        {
            context.Prjt.Update(projects);
            context.SaveChanges();
        }

        public void AddProject(Project projects)
        {
            context.Prjt.Add(projects);
            context.SaveChanges();
        }


        // Admin Training Management
        public async Task<List<Training>> GetAllTraining()
        {
            var result = await context.Training.ToListAsync();
            return result;
        }

        public void DeleteTrainingById(int id)
        {
            var dataField = context.Training.Find(id);
            context.Training.Remove(dataField);
            context.SaveChanges();
        }

        public void EditTrainingById(Training trainings)
        {
            context.Training.Update(trainings);
            context.SaveChanges();
        }

        public void AddTraining(Training trainings)
        {
            context.Training.Add(trainings);
            context.SaveChanges();
        }


        // Admin Leaves Management
        public async Task<List<Leaves>> GetAllLeaves()
        {
            var result = await context.Leave.ToListAsync();
            return result;
        }

        public void DeleteLeavesById(int id)
        {
            var dataField = context.Leave.Find(id);
            context.Leave.Remove(dataField);
            context.SaveChanges();
        }

        public void EditLeavesById(Leaves leaves)
        {
            context.Leave.Update(leaves);
            context.SaveChanges();
        }

        public void AddLeaves(Leaves leaves)
        {
            context.Leave.Add(leaves);
            context.SaveChanges();
        }


        // Common To All Types of Users

        // Employee
        public EmpDeptPosSalViewModel GetFullDetailsOfEmployeeByEmail(string email)
        {
            var result = (from d in context.Emp
                          join d1 in context.Dept on d.DeptId equals d1.DeptId
                          join d2 in context.Post on d.PositionId equals d2.PositionId
                          join d3 in context.Sal on d.SalaryId equals d3.SalaryId
                          where d.Email == email
                          select new EmpDeptPosSalViewModel()
                          {
                              EmpId = d.EmpId,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              SalaryId = d3.SalaryId,
                              Address = d.Address,
                              Email = d.Email,
                              Sex = d.Sex,
                              PhoneNumber = d.PhoneNumber,
                              DOB = d.DOB,
                              Image = d.Image,
                              DeptId = d1.DeptId,
                              DeptName = d1.DeptName,
                              PositionId = d2.PositionId,
                              PositionName = d2.PositionName,
                              BasicPay = d3.BasicPay,
                              Beneficiaries = d3.Beneficiaries,
                              ProvidentFund = d3.ProvidentFund
                          }).FirstOrDefault();
            return result;
        }


        public void EditEmpDetailsByEmp(string EmpID, string LastName, string PhoneNo, string Address)
        {
            var employee = context.Emp.Find(EmpID);
            employee.LastName = LastName;
            employee.PhoneNumber = PhoneNo;
            employee.Address = Address;
            context.Emp.Update(employee);
            context.SaveChanges();
        }

        public List<EmpDeptPosSalViewModel> SearchEmployee()
        {

            var result = (from d in context.Emp
                          join d1 in context.Dept on d.DeptId equals d1.DeptId
                          select new EmpDeptPosSalViewModel()
                          {
                              EmpId = d.EmpId,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              Address = d.Address,
                              Email = d.Email,
                              Sex = d.Sex,
                              PhoneNumber = d.PhoneNumber,
                              DOB = d.DOB,
                              Image = d.Image,
                              DeptId = d1.DeptId,
                              DeptName = d1.DeptName
                          }).ToList();
            return result;

        }

        public List<Employee> GetAllEmployees()
        {
            var query = context.Emp.ToList();
            return query;
        }


        // Leave
        public List<LeaveViewModel> GetEmployeeLeaveView()
        {
            var result = (from d in context.Emp
                          join d1 in context.LeaveApp on d.EmpId equals d1.EmpId
                          join d2 in context.Leave on d1.LeaveId equals d2.LeaveId
                          select new LeaveViewModel()
                          {
                              Days = d1.Days,
                              Description = d1.Description,
                              EmpId = d.EmpId,
                              EndDate = d1.EndDate,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              LeaveDays = d2.LeaveDays,
                              LeaveName = d2.LeaveName,
                              StartDate = d1.StartDate,
                              Status = d1.Status,
                              LeaveAppId = d1.LeaveAppId,
                              LeaveId = d2.LeaveId
                          }).ToList();
            return result;
        }


        /// <summary>
        public List<LeaveViewModel> GetEmployeeLeaveView(string email)
        {
            var result = (from d in context.Emp
                          join d1 in context.LeaveApp on d.EmpId equals d1.EmpId
                          join d2 in context.Leave on d1.LeaveId equals d2.LeaveId
                          where d.Email == email
                          select new LeaveViewModel()
                          {
                              Days = d1.Days,
                              Description = d1.Description,
                              EmpId = d.EmpId,
                              EndDate = d1.EndDate,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              LeaveDays = d2.LeaveDays,
                              LeaveName = d2.LeaveName,
                              StartDate = d1.StartDate,
                              Status = d1.Status,
                              LeaveAppId = d1.LeaveAppId,
                              LeaveId = d2.LeaveId
                          }).ToList();
            return result;
        }
        /// </summary>


        public List<Leaves> GetAllLeavesName()
        {
            var result = context.Leave.ToList();
            return result;
        }

        public void AddLeaveApplicationDetails(LeaveApplication model)
        {
            context.LeaveApp.Add(model);
            context.SaveChanges();
        }

        public int GetLeavesById(int id)
        {
            var result = (from d in context.Leave
                          where d.LeaveId == id
                          select d.LeaveDays).FirstOrDefault();
            return result;
        }

        public int GetLeavesAllotted(string EmpID, int id)
        {
            var result = (from d in context.LeaveApp
                          where d.EmpId == EmpID && d.LeaveId == id && (d.Status == "Approved" || d.Status == "Pending")
                          //group d by d.Status into g
                          //select new { status = g.Key, count = g.Sum(d => d.Status == "Approved" ? 1 : d.Status == "Pending" ? 1 : 0) }).ToList();
                          select d.Days).Sum();
            // return result.Sum(r => r.count);
            return result;
        }

        public void DeleteLeaveAppById(int id)
        {
            var dataField = context.LeaveApp.Find(id);
            context.LeaveApp.Remove(dataField);
            context.SaveChanges();
        }

        public LeaveApplication LeaveDetailsById(int id)
        {
            var result = (from d in context.LeaveApp
                          where d.LeaveAppId == id
                          select d).FirstOrDefault();
            return result;
        }
        public void ApproveLeaveAppById(LeaveApplication model)
        {
            context.LeaveApp.Update(model);
            context.SaveChanges();
        }

        // Training
        public List<TrainingViewModel> GetTrainingView()
        {
            var result = (from d in context.Emp
                          join d1 in context.TrainingApp on d.EmpId equals d1.EmpId
                          join d2 in context.Training on d1.TrainingId equals d2.TrainingId
                          select new TrainingViewModel()
                          {
                              TrainingId = d2.TrainingId,
                              TrainingAppId = d1.TrainingAppId,
                              TrainingName = d2.TrainingName,
                              TrainingDetails = d2.TrainingDetails,
                              EmpId = d.EmpId,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              Description = d1.Description,
                              StartDate = d1.StartDate,
                              EndDate = d1.EndDate,
                              Status = d1.Status
                          }).ToList();
            return result;
        }

        //
        public List<TrainingViewModel> GetTrainingView(string email)
        {
            var result = (from d in context.Emp
                          join d1 in context.TrainingApp on d.EmpId equals d1.EmpId
                          join d2 in context.Training on d1.TrainingId equals d2.TrainingId
                          where d.Email == email
                          select new TrainingViewModel()
                          {
                              TrainingId = d2.TrainingId,
                              TrainingAppId = d1.TrainingAppId,
                              TrainingName = d2.TrainingName,
                              TrainingDetails = d2.TrainingDetails,
                              EmpId = d.EmpId,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              Description = d1.Description,
                              StartDate = d1.StartDate,
                              EndDate = d1.EndDate,
                              Status = d1.Status
                          }).ToList();
            return result;
        }
        //


        public List<Training> GetAllTrainingName()
        {
            var result = context.Training.ToList();
            return result;
        }

        public void AddTrainingApplicationDetails(TrainingApplication model)
        {
            context.TrainingApp.Add(model);
            context.SaveChanges();
        }

        public string GetTrainingDetailsById(int id)
        {
            var result = context.Training.Find(id);
            return result.TrainingDetails;
        }

        public TrainingApplication GetTrainingFullDetailsById(int id)
        {
            var result = (from d in context.TrainingApp
                          where d.TrainingAppId == id
                          select d).FirstOrDefault();
            return result;
        }

        public void ApproveTrainingAppById(TrainingApplication model)
        {
            context.TrainingApp.Update(model);
            context.SaveChanges();
        }
        public void DeleteTrainingAppById(int id)
        {
            var dataField = context.LeaveApp.Find(id);
            context.LeaveApp.Remove(dataField);
            context.SaveChanges();
        }

        // Project

        public List<ProjectViewModel> GetProjectView()
        {
            var result = (from d in context.Emp
                          join d1 in context.PrjtApp on d.EmpId equals d1.EmpId
                          join d2 in context.Prjt on d1.PrjtId equals d2.PrjtId
                          select new ProjectViewModel()
                          {
                              EmpId = d.EmpId,
                              PrjtId = d2.PrjtId,
                              PrjtDescription = d2.PrjtDescription,
                              PrjtName = d2.PrjtName,
                              ProjectStatus = d1.ProjectStatus,
                              EndTime = d1.EndTime,
                              StartTime = d1.StartTime,
                              FirstName = d.FirstName
                          }).Distinct().ToList();
            return result;
        }

        public void AddProjectApp(ProjectApplication projApp)
        {
            context.PrjtApp.Add(projApp);
            context.SaveChanges();
        }

        public ProjectApplication GetProjectFullDetailsByIds(string empId, int prjtid)
        {
            var result = (from d in context.PrjtApp
                          where d.PrjtId == prjtid && d.EmpId == empId
                          select d).FirstOrDefault();
            return result;
        }

        public void UpdateProjectApp(ProjectApplication model)
        {
            context.PrjtApp.Update(model);
            context.SaveChanges();
        }

        public List<ProjectViewModel> ProjectAssignedToUser(string empId)
        {
            var result = (from d in context.Emp
                          join d1 in context.PrjtApp on d.EmpId equals d1.EmpId
                          join d2 in context.Prjt on d1.PrjtId equals d2.PrjtId
                          where d.EmpId == empId
                          select new ProjectViewModel()
                          {
                              EmpId = d.EmpId,
                              PrjtId = d2.PrjtId,
                              PrjtDescription = d2.PrjtDescription,
                              PrjtName = d2.PrjtName,
                              ProjectStatus = d1.ProjectStatus,
                              EndTime = d1.EndTime,
                              StartTime = d1.StartTime,
                              FirstName = d.FirstName
                          }).ToList();
            return result;
        }
    }
}
