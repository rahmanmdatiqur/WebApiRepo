using CIM.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CIM.DAL.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private AppDbContext _context = null;
        private DbSet<T> table= null;
        public GenericRepo(AppDbContext appDbContext)
        {
            _context = appDbContext;
            table=_context.Set<T>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Create(T entity)
        {
            table.Add(entity);
        }

        public void Delete(object id)
        {
            T existing=table.Find(id);
            table.Remove(existing);
        }

        public IQueryable<T> FindAll()
        {
            return table.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
