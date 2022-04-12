using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Webbandohh.Models;

namespace Webbandohh.Repository
{
    public interface IOrder : IRepository<Order>
    {
        void AddOrder(Order order, List<OrderDetail> listOrderDetail);
    }
}