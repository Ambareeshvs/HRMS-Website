using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.ViewModels
{
    public class LeaveViewModel
    {
        public int LeaveId { get; set; }
        [Display(Name = "Leave Name")]

        public string LeaveName { get; set; }
        [Display(Name = "Leave Days")]

        public int LeaveDays { get; set; }


        public int LeaveAppId { get; set; }
        public string EmpId { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public int Days { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
    }
}
