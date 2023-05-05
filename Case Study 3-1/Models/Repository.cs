using Microsoft.EntityFrameworkCore;

namespace Case_Study_3_1.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected SportsProContext context { get; set; }
        private DbSet<T> dbset { get; set; }

        public Repository(SportsProContext ctx)
        {
            context = ctx;
            dbset = context.Set<T>();
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public T? Get(int id)
        {
            return dbset.Find(id);
        }

        public T? Get(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.FirstOrDefault();
        }

        public void Insert(T entity)
        {
            dbset.Add(entity);
        }

        public IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbset.Update(entity);
        }

        private IQueryable<T> BuildQuery(QueryOptions<T> options)
        {
            IQueryable<T> query = dbset;

            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
            {
                query.Where(options.Where);
            }
            if (options.HasOrderBy)
            {
                query.OrderBy(options.OrderBy);
            }
            return query;
        }
    }
}
