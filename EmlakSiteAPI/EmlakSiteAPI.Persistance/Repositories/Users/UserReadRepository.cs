using EmlakSiteAPI.Application.Repositories.Users;
using EmlakSiteAPI.Domain.Entities;
using EmlakSiteAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakSiteAPI.Persistance.Repositories.Users
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(EmlakSiteDbContext context) : base(context)
        {
        }
    }
}
