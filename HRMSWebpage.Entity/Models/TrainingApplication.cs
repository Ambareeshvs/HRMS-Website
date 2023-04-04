using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.Models
{
    public class TrainingApplication
    {
        [Key]
        public int TrainingAppId { get; set; }
        public int TrainingId { get; set; }
        public string EmpId { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int TrainingDeleted { get; set; } = 0;

    }
}
