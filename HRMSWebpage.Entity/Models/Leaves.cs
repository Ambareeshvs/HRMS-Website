using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.Models
{
    public class Leaves
    {
        [Key]
        [Display(Name = "Leave ID")]
        public int LeaveId { get; set; }
        [Display(Name = "Leave Name")]
        public string LeaveName { get; set; }
        [Display(Name = "Leave Days")]
        public int LeaveDays { get; set; }
    }
}
