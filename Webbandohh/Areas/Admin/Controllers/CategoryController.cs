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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        internal CategoryServices db = new CategoryServices();

        public ActionResult Index(string search, int page = 1, int pageSize = 2)
        {
            var list = db.ListAllPaging(search, page, pageSize);
            ViewBag.Search = search;
            return View(list);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Insert(category);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var cate = db.GetById(id);
            return View(cate);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Update(category);
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