using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webbandohh.Repository;

namespace Webbandohh.Servies
{
    public class ItemServices
    {
        private IItem db;

        public ItemServices()
        {
            db = new ItemRepository(new ApplicationDbContext());
        }

        public ICollection<Item> GetAll()
        {
            return db.GetAll();
        }

        public Item GetById(int id)
        {
            return db.GetById(id);
        }

        public int Insert(Item t)
        {
            db.Insert(t);
            return db.Save();
        }

        public int Update(Item t)
        {
            db.Update(t);
            return db.Save();
        }

        public int Delete(int id)
        {
            db.Delete(id);
            return db.Save();
        }

        public ICollection<Item> GetPartialItem()
        {
            return db.GetPartial();
        }

        public int CountProducerAll()
        {
            return db.CountAll();
        }
        public IEnumerable<Item> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }
}