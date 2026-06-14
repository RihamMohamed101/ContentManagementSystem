using BLL.Interfaces;
using DAL.Data;
using DAL.DomainModel;
using System;
using System.Collections.Generic;
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
        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
