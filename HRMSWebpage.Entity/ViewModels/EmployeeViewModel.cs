using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.ViewModels
{
    public class EmployeeViewModel
    {
        [Required]
        [Display(Name = "Employee ID")]
        public string EmpId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string ? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string ? LastName { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string ? Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [MaxLength(12)]
        [MinLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime  DOB { get; set; }
        [Required]
        public string ? Sex { get; set; }
        [Required]
        public string ? Address { get; set; }
        [Required]
        [Display(Name = "Department ID")]
        public int DeptId { get; set; }
        [Required]
        [Display(Name = "Position ID")]
        public int PositionId { get; set; }
        [Required]
        [Display(Name = "Salary ID")]
        public int SalaryId { get; set; }
        [Required]
        [Display(Name = "Upload Image")]
        public string? Image { get; set; }
        public IFormFile ? ImgName { get; set; }
        public int? EmpDeleted { get; set; } = 0;
    }
}
