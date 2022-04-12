using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Webbandohh.Repository
{
    public class ProducerRepository: IProducer
    {
        private ApplicationDbContext dBContext;
        public ProducerRepository(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public ICollection<Producer> GetAll()
        {
            return dBContext.Producers.ToList();
        }

        public Producer GetById(object id)
        {
            return dBContext.Producers.Where(x => x.ProId == Convert.ToInt32(id)).SingleOrDefault();
        }

        public void Insert(Producer t)
        {
            dBContext.Producers.Add(t);
        }

        public void Update(Producer t)
        {
            dBContext.Entry<Producer>(t).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var pro = dBContext.Producers.Where(x => x.ProId == id).SingleOrDefault();
            dBContext.Producers.Remove(pro);
        }

        public int Save()
        {
            return dBContext.SaveChanges();
        }

        public ICollection<Producer> GetPartial()
        {
            return dBContext.Producers.Take(6).ToList();
        }

        public int CountAll()
        {
            int result = dBContext.Producers.ToList().Count;
            return result;
        }

        public IEnumerable<Producer> ListAllPaging(string search, int page, int pageSize)
        {
            IQueryable<Producer> model = dBContext.Producers;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.Name.Contains(search));
            }
            return model.OrderBy(x => x.ProId).ToPagedList(page, pageSize);
        }
    }
}