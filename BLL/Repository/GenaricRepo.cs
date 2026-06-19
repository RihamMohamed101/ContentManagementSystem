using BLL.Interfaces;
using DAL.Data;
using DAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Repository
{
    public class GenaricRepo<T>:IGenaricRepo<T> where T : BaseModel
    {

        private protected readonly AppDbContext _db;


        public GenaricRepo(AppDbContext db)
        {
            _db = db;
        }

        public virtual void Add(T entity)
        {

            _db.Add(entity);
        }

        public void Delete(T entity)
        {
            _db.Remove(entity);
        }

        public T Get(int id) => _db.Set<T>().Find(id);

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).ToList();
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }

       
    }
}
