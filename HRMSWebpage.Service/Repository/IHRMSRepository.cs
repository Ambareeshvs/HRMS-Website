using HRMSWebpage.Entity.Models;
using HRMSWebpage.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Service.Repository
{
    public interface IHRMSRepository
    {
        // Admin Departments
        Task<List<Department>> GetAllDepartments();
        void DeleteDeptById(int id);
        void EditDeptById(Department department);
        void AddDept(Department department);

        // Admin Positions
        Task<List<Position>> GetAllPositions();
        void DeletePositionById(int id);
        void EditPositionById(Position positions);
        void AddPosition(Position positions);

        // Admin Salary
        Task<List<Salary>> GetAllSalary();
        void DeleteSalaryById(int id);
        void EditSalaryById(Salary salary);
        void AddSalary(Salary salary);

        // Admin User
        void EditUserById(Employee employee);
        void DeleteUserById(string id);

        // Admin Projects
        Task<List<Project>> GetAllProjects();
        void DeleteProjectById(int id);
        void EditProjectById(Project projects);
        void AddProject(Project projects);


        // Admin Trainings 
        Task<List<Training>> GetAllTraining();
        void DeleteTrainingById(int id);
        void EditTrainingById(Training trainings);
        void AddTraining(Training trainings);


        // Admin Leaves
        Task<List<Leaves>> GetAllLeaves();
        void DeleteLeavesById(int id);
        void EditLeavesById(Leaves leaves);
        void AddLeaves(Leaves leaves);


        // Common Users
        EmpDeptPosSalViewModel GetFullDetailsOfEmployeeByEmail(string email);
        void EditEmpDetailsByEmp(string EmpID, string LastName, string PhoneNo, string Address);
        List<EmpDeptPosSalViewModel> SearchEmployee();
        List<Employee> GetAllEmployees();

        // Common Users -> Leaves
        List<LeaveViewModel> GetEmployeeLeaveView();

        /// <summary>
        List<LeaveViewModel> GetEmployeeLeaveView(string email);
        /// </summary>

        List<Leaves> GetAllLeavesName();
        void AddLeaveApplicationDetails(LeaveApplication model);
        int GetLeavesById(int id);
        int GetLeavesAllotted(string EmpID, int id);
        void DeleteLeaveAppById(int id);
        LeaveApplication LeaveDetailsById(int id);
        void ApproveLeaveAppById(LeaveApplication model);

        // Common Users -> Training
        List<TrainingViewModel> GetTrainingView();

        //
        List<TrainingViewModel> GetTrainingView(string email);
        //
        List<Training> GetAllTrainingName();
        void AddTrainingApplicationDetails(TrainingApplication model);
        string GetTrainingDetailsById(int id);
        TrainingApplication GetTrainingFullDetailsById(int id);
        void ApproveTrainingAppById(TrainingApplication model);

        // HR -> Project Assigning
        List<ProjectViewModel> GetProjectView();
        void AddProjectApp(ProjectApplication projApp);
        ProjectApplication GetProjectFullDetailsByIds(string empId, int prjtid);
        void UpdateProjectApp(ProjectApplication model);
        List<ProjectViewModel> ProjectAssignedToUser(string empId);
    }
}
