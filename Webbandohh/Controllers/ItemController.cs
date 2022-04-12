using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbandohh.Servies;

namespace Webbandohh.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        ItemServices db = new ItemServices();
        public ActionResult Index(string search, int page = 1, int pageSize = 6)
        {
            var list = db.ListAllPaging(search, page, pageSize);
            ViewBag.Search = search;
            return View(list);
        }
    }
}