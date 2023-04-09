using ATSPro.Api.Core.Application.Interfaces;
using ATSPro.Api.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq.Expressions;

namespace ATSPro.Api.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {

        private readonly AtsProServerContext atsProServerContext;

        public GenericRepository(AtsProServerContext atsProServerContext)
        {
            this.atsProServerContext = atsProServerContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this.atsProServerContext.Set<T>().AddAsync(entity);
            await this.atsProServerContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.atsProServerContext.Set<T>().AsNoTracking()
                .ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this.atsProServerContext
                .Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await this.atsProServerContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            this.atsProServerContext.Set<T>().Remove(entity);
            await this.atsProServerContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.atsProServerContext.Set<T>().Update(entity);
            await this.atsProServerContext.SaveChangesAsync();

        }
    }
}
