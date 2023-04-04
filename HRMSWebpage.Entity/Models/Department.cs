using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.Models
{
    public class Department
    {
        [Key]
        [Display(Name = "Department ID")]
        public int DeptId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Department Name")]
        public string ? DeptName { get; set; }
        public int DeptDeleted { get; set; } = 0;

    }
}
