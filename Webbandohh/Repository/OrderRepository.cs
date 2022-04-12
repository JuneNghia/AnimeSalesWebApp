using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;

namespace Webbandohh.Repository
{
    public class OrderRepository: IOrder
    {
        private ApplicationDbContext dBContext;

        public OrderRepository(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public void AddOrder(Order order, List<OrderDetail> listOrderDetail)
        {
            using (DbContextTransaction transaction = dBContext.Database.BeginTransaction())
            {
                try
                {
                    var AddOrder = dBContext.Orders.Add(order);
                    int orderId = AddOrder.OrderId;
                    foreach (var item in listOrderDetail)
                    {
                        item.OrderId = orderId;
                        Item i = dBContext.Items.Find(item.ItemId);
                        int orderQuantity = item.Quantity;
                        if (i.Quantity >= orderQuantity)
                        {
                            i.Quantity -= orderQuantity;
                            dBContext.OrderDetails.Add(item);
                            dBContext.Entry(i).State = EntityState.Modified;
                        }
                        else
                        {
                            throw new Exception(i.Title + "sách trong kho không đủ số lượng.");
                        }
                    }
                    dBContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {

                    transaction.Rollback();
                }
            }
        }

        public int CountAll()
        {
            return dBContext.Orders.Count();
        }


        public IEnumerable<Order> ListAllPaging(string search, int page, int pageSize)
        {
            IQueryable<Order> model = dBContext.Orders;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.User.UserName.Contains(search));
            }
            return model.OrderBy(x => x.OrderId).ToPagedList(page, pageSize);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(object id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetPartial()
        {
            throw new NotImplementedException();
        }

        public void Insert(Order t)
        {
            throw new NotImplementedException();
        }



        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Order t)
        {
            throw new NotImplementedException();
        }
    }
}