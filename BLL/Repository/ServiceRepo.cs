using BLL.Interfaces;
using DAL.Data;
using DAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    internal class ServiceRepo:GenaricRepo<Service> , IServiceRepo
    {
        public ServiceRepo(AppDbContext db):base(db)
        {
            
        }
    }
}
