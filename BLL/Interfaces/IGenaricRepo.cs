using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IGenaricRepo<T>
    {

        public void Add(T Entity);
        public void Update(T Entity);
        public void Delete(T Entity);
    }
}
