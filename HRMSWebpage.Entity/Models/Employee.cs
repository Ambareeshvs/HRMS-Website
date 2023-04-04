using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "Employment ID")]
        public string EmpId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        [Display(Name = "Department ID")]
        public int DeptId { get; set; }
        [Display(Name = "Position ID")]
        public int PositionId { get; set; }
        [Display(Name = "Salary ID")]
        public int SalaryId { get; set; }
        public string ? Image { get; set; }
        public int EmpDeleted { get; set; } = 0;
        [NotMapped]
        public IFormFile? ImgName { get; set; }
    }
}
