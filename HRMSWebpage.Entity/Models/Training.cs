using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRMSWebpage.Entity.Models
{
    public class Training
    {
        [Display(Name = "Training ID")]
        public int TrainingId { get; set; }
        [Display(Name = "Training Name")]

        public string TrainingName { get; set; }
        [Display(Name = "Training Details")]

        public string TrainingDetails { get; set; }
    }
}
