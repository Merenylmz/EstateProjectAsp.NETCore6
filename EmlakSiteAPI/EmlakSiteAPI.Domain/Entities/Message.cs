using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmlakSiteAPI.Domain.Entities.Common;

namespace EmlakSiteAPI.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string MessageTitle { get; set; }
        public string Email { get; set; }
        public string MessageDescription { get; set; }
    }
}
