using BLL.Interfaces;
using DAL.Data;
using DAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public class AboutRepo : GenaricRepo<AboutSection>, IAboutRepo
    {
        public AboutRepo(AppDbContext db):base(db)
        {
            
        }
    }
}
