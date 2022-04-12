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
    public class ProducerController : Controller
    {
        // GET: Admin/Producer
        internal ProducerServices db = new ProducerServices();

        public ActionResult Index(string search, int page = 1, int pageSize = 2)
        {
            var list = db.ListAllPaging(search, page, pageSize);
            ViewBag.search = search;
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producer pro)
        {
            if (ModelState.IsValid)
            {
                db.Insert(pro);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var pro = db.GetById(id);
            return View(pro);
        }

        [HttpPost]
        public ActionResult Edit(Producer pro)
        {
            if (ModelState.IsValid)
            {
                db.Update(pro);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}