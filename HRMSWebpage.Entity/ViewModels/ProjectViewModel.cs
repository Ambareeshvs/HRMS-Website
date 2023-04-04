using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRMSWebpage.Entity.ViewModels
{
    public class ProjectViewModel
    {
        public string EmpId { get; set; }
        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        [Display(Name = "Project ID")]
        public int PrjtId { get; set; }
        [Display(Name = "Project Name")]
        public string PrjtName { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        [Display(Name = "Project Status")]

        public string ProjectStatus { get; set; }
        [Display(Name = "Project Description")]

        public string PrjtDescription { get; set; }
    }
}
