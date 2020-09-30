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

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveAllAsync();
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveAllAsync();
        }

        /// <summary>
        /// Check if entity exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(int id) =>
            await _context.Set<T>().AnyAsync(e => e.Id == id);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll() =>
            _context.Set<T>()
            .AsNoTracking();

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id) =>
            await _context.Set<T>()
            .AsNoTracking().
            FirstOrDefaultAsync(e => e.Id == id);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveAllAsync();
        }

        /// <summary>
        /// Save changes to database
        /// </summary>
        /// <returns></returns>
        async Task<bool> SaveAllAsync() =>
            await _context.SaveChangesAsync() > 0;
    }
}
