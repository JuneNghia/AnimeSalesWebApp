using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webbandohh.Repository
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();

        T GetById(object id);

        void Insert(T t);

        void Update(T t);

        void Delete(int id);

        int Save();
        ICollection<T> GetPartial();
        int CountAll();
        IEnumerable<T> ListAllPaging(string searh, int page, int pageSize);
    }
}