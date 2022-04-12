using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbandohh.Models;
using Webbandohh.Servies;

namespace Webbandohh.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        Servies.ProducerServices producer = new Servies.ProducerServices();
        Servies.CreatorServices creator = new Servies.CreatorServices();
        Servies.CategoryServices category = new Servies.CategoryServices();
        Servies.OrderServices order = new Servies.OrderServices();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                TempData["CountProducer"] = producer.CountProducerAll();
                TempData["CountCreator"] = creator.CountCreatorAll();
                TempData["CountCategory"] = category.CountCategoryAll();
                TempData["CountOrder"] = order.CountOrder();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}