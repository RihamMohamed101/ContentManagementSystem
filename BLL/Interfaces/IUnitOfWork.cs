using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IAboutRepo AboutRepo { get; set; }

        public IHeroRepo HeroRepo { get; set; }

        public IContactRepo ContactRepo { get; set; }

        public IServiceRepo serviceRepo { get; set; }


        public int Complete();

        public void Dispose();
    }
}
