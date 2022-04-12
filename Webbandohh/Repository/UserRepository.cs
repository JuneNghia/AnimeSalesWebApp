using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Webbandohh.Repository
{
    public class UserRepository: IUserRepository
    {
        private ApplicationDbContext dBContext;

        public UserRepository(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }


        public int CountAll()
        {
            int result = dBContext.Users.ToList().Count;
            return result;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(object id)
        {
            var i = Convert.ToString(id.ToString());
            return dBContext.Users.Where(x => x.Id == i).SingleOrDefault();

        }

        public ICollection<ApplicationUser> GetPartial()
        {
            throw new NotImplementedException();
        }

        public void Insert(ApplicationUser t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> ListAllPaging(string searh, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return dBContext.SaveChanges();
        }

        public void Update(ApplicationUser t)
        {
            dBContext.Set<ApplicationUser>().AddOrUpdate(t);
        }
    }
}