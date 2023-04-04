using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.ViewModels
{
    public class TrainingViewModel
    {
        public int TrainingId { get; set; }
        public string TrainingName { get; set; }
        public string TrainingDetails { get; set; }

        public int TrainingAppId { get; set; }
        public string EmpId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
