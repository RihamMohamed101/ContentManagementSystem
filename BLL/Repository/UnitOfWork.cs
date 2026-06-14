using BLL.Interfaces;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public IAboutRepo AboutRepo { get; set; }
        public IHeroRepo HeroRepo { get; set ; }
        public IContactRepo ContactRepo { get; set ; }
        public IServiceRepo serviceRepo { get; set; }


        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            AboutRepo = new AboutRepo(db);
            HeroRepo = new HeroRepo(db);
            ContactRepo = new ContactRepo(db);
            serviceRepo = new ServiceRepo(db);
        }

        public int Complete()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
