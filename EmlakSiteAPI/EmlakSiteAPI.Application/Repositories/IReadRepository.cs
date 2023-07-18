using EmlakSiteAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmlakSiteAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);//Bütün Verileri
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);//Yolladığımız Şarttaki verileri 
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true); //Yolladığımız Şarttaki ilk veriyi
        Task<T> GetByIdAsync(string id, bool tracking = true);//Id ye göre getirme
    }
}
