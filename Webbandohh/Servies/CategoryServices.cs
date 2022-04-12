using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webbandohh.Repository;

namespace Webbandohh.Servies
{
    public class CategoryServices
    {
        private ICategory db;
        public CategoryServices()
        {
            db = new CategoryRepository(new ApplicationDbContext());
        }

        public ICollection<Category> GetAll()
        {
            return db.GetAll();
        }

        public Category GetById(int id)
        {
            return db.GetById(id);
        }
        public int Insert(Category t)
        {
            db.Insert(t);
            return db.Save();
        }
        public int Update(Category t)
        {
            db.Update(t);
            return db.Save();
        }
        public int Delete(int id)
        {
            db.Delete(id);
            return db.Save();
        }
        public ICollection<Category> GetPartialCategory()
        {
            return db.GetPartial();
        }
        public int CountCategoryAll()
        {
            return db.CountAll();
        }

        public IEnumerable<Category> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }
}