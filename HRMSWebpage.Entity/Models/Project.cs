using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.Models
{
    public class Project
    {
        [Key]
        [Display(Name = "Project ID")]
        public int PrjtId { get; set; }
        [Display(Name = "Project Name")]
        public string PrjtName { get; set; }
        [Display(Name = "Project Description")]

        public string PrjtDescription { get; set; }
    }
}
