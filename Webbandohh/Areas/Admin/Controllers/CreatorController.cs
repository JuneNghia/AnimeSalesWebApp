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
    public class CreatorController : Controller
    {
        // GET: Admin/Creator
        internal CreatorServices db = new CreatorServices();
        [Authorize]
        public ActionResult Index(string search, int page = 1, int pageSize = 2)
        {

            var list = db.ListAllPaging(search, page, pageSize);
            ViewBag.Search = search;
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Creator creator)
        {
            if (ModelState.IsValid)
            {
                db.Insert(creator);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var cre = db.GetById(id);
            return View(cre);
        }

        [HttpPost]
        public ActionResult Edit(Creator creator)
        {
            if (ModelState.IsValid)
            {
                db.Update(creator);
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