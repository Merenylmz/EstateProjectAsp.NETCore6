using EmlakSiteAPI.Application.Repositories;
using EmlakSiteAPI.Application.Repositories.Adverts;
using EmlakSiteAPI.Domain.Entities;
using EmlakSiteAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakSiteAPI.Persistance.Repositories.Adverts
{
    public class AdvertReadRepository : ReadRepository<Advert>, IAdvertReadRepository
    {
        public AdvertReadRepository(EmlakSiteDbContext context) : base(context)
        {
        }
    }
}
