using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Webbandohh.Repository
{
    public class CreatorRepository: ICreator
    {
        private ApplicationDbContext dBContext;

        public CreatorRepository(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public ICollection<Creator> GetAll()
        {
            return dBContext.Creators.ToList();
        }

        public Creator GetById(object id)
        {
            return dBContext.Creators.Where(x => x.CreatorId == Convert.ToInt32(id)).SingleOrDefault();

        }

        public void Insert(Creator t)
        {
            dBContext.Creators.Add(t);
        }

        public void Update(Creator t)
        {
            dBContext.Entry<Creator>(t).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var author = dBContext.Creators.Where(x => x.CreatorId == id).SingleOrDefault();
        }

        public int Save()
        {
            return dBContext.SaveChanges();
        }

        public ICollection<Creator> GetPartial()
        {
            return dBContext.Creators.Take(6).ToList();
        }

        public int CountAll()
        {
            var cre = dBContext.Creators.ToList();
            int result = cre.Count;
            return result;
        }

        public IEnumerable<Creator> ListAllPaging(string search, int page, int pageSize)
        {
            IQueryable<Creator> model = dBContext.Creators;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.CreatorName.Contains(search));
            }
            return model.OrderBy(x => x.CreatorName).ToPagedList(page, pageSize);
        }
    }
}