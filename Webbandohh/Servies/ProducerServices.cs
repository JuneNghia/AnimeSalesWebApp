using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webbandohh.Repository;

namespace Webbandohh.Servies
{
    public class ProducerServices
    {
        private IProducer db;
        public ProducerServices()
        {
            db = new ProducerRepository(new ApplicationDbContext());
        }

        public ICollection<Producer> GetAll()
        {
            return db.GetAll();
        }

        public Producer GetById(int id)
        {
            return db.GetById(id);
        }
        public int Insert(Producer t)
        {
            db.Insert(t);
            return db.Save();
        }
        public int Update(Producer t)
        {
            db.Update(t);
            return db.Save();
        }
        public int Delete(int id)
        {
            db.Delete(id);
            return db.Save();
        }
        public ICollection<Producer> GetPartialProducer()
        {
            return db.GetPartial();
        }
        public int CountProducerAll()
        {
            return db.CountAll();
        }
        public IEnumerable<Producer> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }
}