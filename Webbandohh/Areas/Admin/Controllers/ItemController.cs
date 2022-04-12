using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using Webbandohh.Models;
using Webbandohh.Servies;

namespace Webbandohh.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ItemController : Controller
    {
        // GET: Admin/Item
        internal ItemServices db = new ItemServices();
        CategoryServices cate = new CategoryServices();
        CreatorServices cre = new CreatorServices();
        ProducerServices pro = new ProducerServices();

        public ActionResult Index(string search, int page = 1, int pageSize = 2)
        {
            var list = db.ListAllPaging(search, page, pageSize);
            ViewBag.Search = search;
            return View(list);
        }

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Item it, HttpPostedFileBase imageFile)
        {

            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(imageFile.FileName);
                string path = Path.Combine(Server.MapPath("~/images"), fileName);
                imageFile.SaveAs(path);
                it.ImgUrl = fileName;
                it.CreateDate = DateTime.Now;
                db.Insert(it);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var it = db.GetById(id);
            SetViewBag(id);
            ViewBag.CreateBook = it.CreateDate;
            return View(it);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Item it, HttpPostedFileBase imageFile)
        {
            if (imageFile != null)
            {
                if (ModelState.IsValid)
                {
                    string fileName = Path.GetFileName(imageFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/images"), fileName);
                    imageFile.SaveAs(path);
                    it.ImgUrl = fileName;
                    it.ModifierDate = DateTime.Now;
                    db.Update(it);
                    return RedirectToAction("Index");

                }
            }
            else
            {
                it.ModifierDate = DateTime.Now;
                db.Update(it);
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
        private void SetViewBag(int? selectedId = null)
        {
            ViewBag.CateId = new SelectList(cate.GetAll(), "CateId", "CateName", selectedId);
            ViewBag.CreatorId = new SelectList(cre.GetAll(), "CreatorId", "CreatorName", selectedId);
            ViewBag.ProId = new SelectList(pro.GetAll(), "ProId", "Name", selectedId);
        }
    }
}