using EmlakSiteAPI.Application.Repositories;
using EmlakSiteAPI.Domain.Entities.Common;
using EmlakSiteAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakSiteAPI.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly EmlakSiteDbContext _context;

        public WriteRepository(EmlakSiteDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<dynamic> AddAsync(T model)
        {
            EntityEntry entityEntry = await Table.AddAsync(model);
            return entityEntry.Entity;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Delete(T model)
        {
            Table.Remove(model);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var model = await Table.FindAsync(Guid.Parse(id));
            return Delete(model);
        }

        public async Task<int> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return 1;
        }

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
