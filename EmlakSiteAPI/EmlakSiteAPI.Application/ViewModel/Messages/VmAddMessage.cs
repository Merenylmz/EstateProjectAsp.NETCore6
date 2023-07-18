using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakSiteAPI.Application.ViewModel.Messages
{

    public class Vm_AddMessage
    {
        public string MessageTitle { get; set; }
        public string Email { get; set; }
        public string MessageDescription { get; set; }
    }
}
