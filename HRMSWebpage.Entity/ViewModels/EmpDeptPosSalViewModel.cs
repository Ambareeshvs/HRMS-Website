using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRMSWebpage.Entity.ViewModels
{
    public class EmpDeptPosSalViewModel
    {
        [Display(Name = "Department ID")]
        public int DeptId { get; set; }
        [StringLength(50)]
        [Display(Name = "Department Name")]
        public string? DeptName { get; set; }



        public string EmpId { get; set; }
        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public int PositionId { get; set; }
        public int SalaryId { get; set; }
        public string? Image { get; set; }


        [StringLength(50)]
        [Display(Name = "Position Name")]
        public string PositionName { get; set; }

        

        public string Beneficiaries { get; set; }
        public float? BasicPay { get; set; }
        public float? ProvidentFund { get; set; }
    }
}
