using EmlakSiteAPI.Application.Repositories.Messages;
using EmlakSiteAPI.Domain.Entities;
using EmlakSiteAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakSiteAPI.Persistance.Repositories.Messages
{
    public class MessageReadRepository : ReadRepository<Message>, IMessageReadRepository
    {
        public MessageReadRepository(EmlakSiteDbContext context) : base(context)
        {
        }
    }
}
