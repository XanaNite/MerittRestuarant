
using MerittRestuarant.Data;
using Microsoft.EntityFrameworkCore;

namespace MerittRestuarant.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context { get; set; }
        private DbSet<T> _dbSet { get; set; }
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, QueryOptions<T> options)
        {
            IQueryable<T> query = _dbSet;
            if (options != null)
            {
                if (options.HasWhere && options.Where != null)
                {
                    query = query.Where(options.Where);
                }
                if (options.HasOrderBy && options.OrderBy != null)
                {
                    query = query.OrderBy(options.OrderBy);
                }

                var includes = options.GetIncludes();

                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var keyProperty = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
            if (keyProperty == null)
            {
                throw new InvalidOperationException($"Entity {typeof(T).Name} does not have a primary key defined.");
            }
            string primaryKeyName = keyProperty.Name;

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
