using BLL.Interfaces;
using DAL.Data;
using DAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    internal class HeroRepo:GenaricRepo<HeroSection> , IHeroRepo
    {
        public HeroRepo(AppDbContext db):base(db)
        {
            
        }
    }
}
