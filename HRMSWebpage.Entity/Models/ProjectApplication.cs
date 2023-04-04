using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.Models
{
    public class ProjectApplication
    {
        [Key]
        public int PrjtAppId { get; set; }
        public int PrjtId { get; set; }
        public string EmpId { get; set; }
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        [Display(Name = "Project Status")]

        public string ProjectStatus { get; set; }
        public int PrjtDeleted { get; set; } = 0;

    }
}
