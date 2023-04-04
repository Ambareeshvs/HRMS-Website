using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.Models
{
    public class Salary
    {
        [Key]
        [Display(Name = "Salary ID")]
        public int SalaryId { get; set; }
        [Display(Name = "Beneficiaries")]

        public string Beneficiaries { get; set; }
        [Display(Name = "Basic Pay")]

        public float? BasicPay { get; set; }
        [Display(Name = "Provident Fund")]

        public float? ProvidentFund { get; set; }
        public int SalaryDeleted { get; set; } = 0;
        //[NotMapped]
        //public string Status { get; set; }

    }
}
