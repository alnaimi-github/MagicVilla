using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace MagicVilla_VillaAPI.Repository
{
    public class Repository<T>: IRepository<T> where T:class 
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.DbSet= db.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null!, bool tracked = true,
            string? includeProperties = null!)
        {
            IQueryable<T> query = DbSet;
            if(!tracked)
            {
                query = query.AsNoTracking();
            }
            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(includeProperties!=null)
            {
                foreach(var include in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                   query=query.Include(include);
                } 
            }

            return (await query.FirstOrDefaultAsync())!;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null!,
            string? includeProperties = null!, int pageSize = 0, int pageNumber = 1)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (pageSize>0)
            {
                if (pageSize>100)
                {
                    pageSize = 100;
                }

                query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            }
            if (includeProperties != null)
            {
                foreach (var include in includeProperties.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();

        }

        public async Task RemoveAsync(T entity)
        {
            DbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync() => await _db.SaveChangesAsync();
    }
}
