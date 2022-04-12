using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbandohh.Servies;

namespace Webbandohh.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        // GET: Admin/Order
        OrderDetailServices detail = new OrderDetailServices();
        public ActionResult Index(string search, int page = 1, int pageSize = 2)
        {
            var list = detail.ListAllPaging(search, page, pageSize);
            ViewBag.Search = search;
            return View(list);
        }
    }
}