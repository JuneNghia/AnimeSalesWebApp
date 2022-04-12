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
    public class OrderDetailServices
    {
        private IOrderDetail db;
        public OrderDetailServices()
        {
            db = new OrderDetailRepository(new ApplicationDbContext());
        }
        public IEnumerable<Webbandohh.Models.OrderDetail> ListAllPaging(string search, int page, int pageSize)
        {
            return db.ListAllPaging(search, page, pageSize);
        }
    }
}