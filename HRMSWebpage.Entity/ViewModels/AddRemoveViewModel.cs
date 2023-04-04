using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRMSWebpage.Entity.ViewModels
{
    public class AddRemoveViewModel
    {
        [Display(Name="Role ID")]
        public string RoleId { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        [Display(Name = "Role Selected")]
        public bool IsSelected { get; set; }

    }
}
