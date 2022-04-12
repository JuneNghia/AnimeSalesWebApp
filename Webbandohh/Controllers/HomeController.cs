using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbandohh.Models;
using Webbandohh.Servies;

namespace Webbandohh.Controllers
{
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";

        internal ItemServices db = new ItemServices();

        internal CategoryServices cate = new CategoryServices();

        internal CreatorServices creator = new CreatorServices();

        internal ProducerServices pro = new ProducerServices();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Category()
        {
            var list = cate.GetPartialCategory();
            ViewBag.CountCategory = cate.CountCategoryAll();
            return PartialView(list);
        }

        public PartialViewResult Producer()
        {
            var list = pro.GetPartialProducer();
            ViewBag.CountProducer = pro.CountProducerAll();
            return PartialView(list);
        }

        public PartialViewResult Creator()
        {
            var listcre = creator.GetPartialCreator();
            ViewBag.CountCreator = creator.CountCreatorAll();
            return PartialView(listcre);
        }

        public PartialViewResult Slide()
        {
            return PartialView();
        }

        public PartialViewResult NewItem()
        {
            var newitem = db.GetPartialItem();
            return PartialView(newitem);
        }

        public ActionResult ItemDetail(int id)
        {
            var item = db.GetById(id);
            return View(item);
        }

        public PartialViewResult ViewCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        public PartialViewResult FuaturesItem()
        {
            var items = db.GetPartialItem();
            return PartialView(items);
        }
    }
}