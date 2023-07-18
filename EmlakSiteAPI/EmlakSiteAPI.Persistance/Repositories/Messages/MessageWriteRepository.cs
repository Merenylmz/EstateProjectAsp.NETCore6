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
    public class MessageWriteRepository : WriteRepository<Message>, IMessageWriteRepository
    {
        public MessageWriteRepository(EmlakSiteDbContext context) : base(context)
        {
        }
    }
}
