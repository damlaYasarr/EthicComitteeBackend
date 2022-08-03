using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Abstract
{
    public interface IEntityRepository<T> where T: class
    {//filtre! ise filtre olmasa da olur demek 
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T, bool>> filter =null);
        List<T> GetById(int user);
        void Add(T user);
        void Update(T user);
        void Delete(T user);
    }
}
