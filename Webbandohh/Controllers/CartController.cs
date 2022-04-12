using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbandohh.Models;
using Webbandohh.Servies;

namespace Webbandohh.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string CartSession = "CartSession";
        private UserServices userService;
        OrderServices orderServices = new OrderServices();
        public CartController()
        {
            userService = new UserServices();
        }
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            else
            {
                ViewBag.Noti = "Giỏ hàng trống!!!";
            }
            return View(list);
        }
        #region additem-cart
        public ActionResult AddItem(int ItemId, int quantity)
        {
            var i = new ItemServices().GetById(ItemId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Item.ItemId == ItemId))
                {
                    foreach (var item in list)
                    {
                        if (item.Item.ItemId == ItemId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Item = i;
                    item.Quantity = quantity;
                    list.Add(item);
                }

                Session[CartSession] = list;

            }
            else
            {

                var item = new CartItem();
                item.Item = i;
                item.Quantity = quantity;
                var list = new List<CartItem>();

                list.Add(item);

                Session[CartSession] = list;
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region delete-cart
        public ActionResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Item.ItemId == id);
            Session[CartSession] = sessionCart;
            if (sessionCart.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        #endregion

        #region addorder
        public ActionResult Payment()
        {
            if (User.Identity.IsAuthenticated)
            {
                var cart = Session[CartSession];
                List<CartItem> listitem = new List<CartItem>();
                if (cart != null)
                {
                    listitem = (List<CartItem>)cart;
                }

                Order order = new Order();
                order.OrderDate = DateTime.Now;

                string userId = User.Identity.GetUserId();
                order.UserId = userId;

                List<OrderDetail> details = new List<OrderDetail>();

                foreach (var item in listitem)
                {
                    details.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ItemId = item.Item.ItemId,
                        Quantity = item.Quantity

                    });
                }
                try
                {
                    orderServices.AddOrder(order, details);
                    Session[CartSession] = null;
                    return RedirectToAction("Success", "Cart");
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Cart");
                }


            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        #endregion

        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult ThongTinKhachHang()
        {
            string userId = User.Identity.GetUserId();
            var user = userService.GetById(userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult ThongTinKhachHang(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var kh = userService.GetById(user.Id);
                    user.PasswordHash = kh.PasswordHash.ToString();
                    user.SecurityStamp = kh.SecurityStamp;

                    userService.Update(user);
                    return RedirectToAction("Payment");
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return View();
            }
        }
    }
}