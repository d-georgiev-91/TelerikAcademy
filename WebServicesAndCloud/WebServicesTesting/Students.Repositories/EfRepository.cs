namespace Students.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected DbContext Context { get; set; }

        protected IDbSet<T> EntitySet { get; set; }

        public EfRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.EntitySet = this.Context.Set<T>();
        }

        public T Add(T entity)
        {
            this.EntitySet.Add(entity);
            this.Context.SaveChanges();

            return entity;
        }

        public T Update(int id, T entity)
        {
            var entityToChange = this.EntitySet.Find(id);

            entityToChange = entity;
            this.Context.SaveChanges();

            return entityToChange;
        }

        public void Delete(int id)
        {
            var entity = this.EntitySet.Find(id);

            if (entity != null)
            {
                this.EntitySet.Remove(entity);
            }
        }

        public T Get(int id)
        {
            var entity = this.EntitySet.Find(id);

            return entity;
        }

        public IQueryable<T> All()
        {
            return this.EntitySet;
        }

        public IQueryable<T> Find(Expression<Func<T, int, bool>> predicate)
        {
            var entities = this.EntitySet.Where(predicate);

            return entities;
        }
    }
}