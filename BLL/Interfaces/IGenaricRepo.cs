using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface IGenaricRepo<T>
    {

        public void Add(T Entity);
        public T Get(int id);
        public List<T> GetAll();
        public void Update(T Entity);
        public void Delete(T Entity);
        public List<T> Find(Expression<Func<T, bool>> predicate);
    }
}
