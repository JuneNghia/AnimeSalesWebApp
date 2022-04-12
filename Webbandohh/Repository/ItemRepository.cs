using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PagedList;

namespace Webbandohh.Repository
{
    public class ItemRepository: IItem
    {
        private ApplicationDbContext dBContext;

        public ItemRepository(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public ICollection<Item> GetAll()
        {
            return dBContext.Items.ToList();
        }

        public Item GetById(object id)
        {
            var i = Convert.ToInt16(id.ToString());
            return dBContext.Items.Where(x => x.ItemId == i).SingleOrDefault();
        }

        public void Insert(Item t)
        {
            dBContext.Items.Add(t);
        }

        public void Update(Item t)
        {
            dBContext.Entry<Item>(t).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = dBContext.Items.SingleOrDefault(x => x.ItemId == id);
            dBContext.Items.Remove(item);
        }

        public int Save()
        {
            return dBContext.SaveChanges();
        }

        public ICollection<Item> GetPartial()
        {
            return dBContext.Items.Take(4).ToList();
        }

        public int CountAll()
        {
            return dBContext.Items.ToList().Count;
        }

        public IEnumerable<Item> ListAllPaging(string search, int page, int pageSize)
        {
            IQueryable<Item> model = dBContext.Items;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.Category.CateName.Contains(search) || x.Producer.Name.Contains(search) || x.Creator.CreatorName.Contains(search) || x.Title.Contains(search));
            }
            return model.OrderBy(x => x.ItemId).ToPagedList(page, pageSize);
        }
    }
}