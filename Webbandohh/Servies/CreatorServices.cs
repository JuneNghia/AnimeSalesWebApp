using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webbandohh.Repository;

namespace Webbandohh.Servies
{
    public class CreatorServices
    {
        private ICreator db;

        public CreatorServices()
        {
            db = new CreatorRepository(new ApplicationDbContext());
        }

        public ICollection<Creator> GetAll()
        {
            return db.GetAll();
        }

        public Creator GetById(int id)
        {
            return db.GetById(id);
        }

        public int Insert(Creator t)
        {
            db.Insert(t);
            return db.Save();
        }

        public int Update(Creator t)
        {
            db.Update(t);
            return db.Save();
        }

        public int Delete(int id)
        {
            db.Delete(id);
            return db.Save();
        }

        public ICollection<Creator> GetPartialCreator()
        {
            return db.GetPartial();
        }

        public int CountCreatorAll()
        {
            return db.CountAll();
        }
        public IEnumerable<Creator> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }
}