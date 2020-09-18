namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Classes
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using NETCore_MVC_Water_Company.Web.Data.Entities;
    using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;

    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public DataContext Context { get; }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveAllAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveAllAsync();
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _context.Set<T>().AnyAsync(e => e.Id == id);

        public IQueryable<T> GetAll() =>
            _context.Set<T>()
            .AsNoTracking();

        public async Task<T> GetByIdAsync(int id) =>
            await _context.Set<T>()
            .AsNoTracking().
            FirstOrDefaultAsync(e => e.Id == id);

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveAllAsync();
        }

        async Task<bool> SaveAllAsync() =>
            await _context.SaveChangesAsync() > 0;
    }
}
