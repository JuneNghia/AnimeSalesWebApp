using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Webbandohh.Repository;

namespace Webbandohh.Servies
{
    public class UserServices
    {
        private IUserRepository db;
        public UserServices()
        {
            db = new UserRepository(new ApplicationDbContext());
        }
        public ICollection<ApplicationUser> GetAll()
        {
            return db.GetAll();
        }

        public ApplicationUser GetById(string id)
        {
            return db.GetById(id);
        }

        public int Insert(ApplicationUser t)
        {
            db.Insert(t);
            return db.Save();
        }

        public int Update(ApplicationUser t)
        {
            db.Update(t);
            return db.Save();
        }

        public int Delete(int id)
        {
            db.Delete(id);
            return db.Save();
        }

        public ICollection<ApplicationUser> GetPartialApplicationUser()
        {
            return db.GetPartial();
        }

        public int CountApplicationUserAll()
        {
            return db.CountAll();
        }
        public IEnumerable<ApplicationUser> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }
}