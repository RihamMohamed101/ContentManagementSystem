using BLL.Interfaces;
using DAL.Data;
using DAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    internal class ContactRepo:GenaricRepo<ContactMessage> , IContactRepo
    {
        public ContactRepo(AppDbContext db):base(db)
        {
            
        }
    }
}
