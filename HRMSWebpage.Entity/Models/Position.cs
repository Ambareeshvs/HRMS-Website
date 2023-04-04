using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.Models
{
    public class Position
    {
        [Key]
        [Display(Name = "Position ID")]
        public int PositionId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Position Name")]
        public string PositionName { get; set; }
        public int PositionDeleted { get; set; } = 0;

    }
}
