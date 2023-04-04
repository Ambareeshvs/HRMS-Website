using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSWebpage.Entity.ViewModels
{
    public class UserResults
    {
        public UserResults()
        {
            AddRemove = new List<AddRemoveViewModel>();
        }
        public string ? Id { get; set; }
        public string ? UserName { get; set; }


        public List<AddRemoveViewModel> AddRemove { get; set; }

    }
}
