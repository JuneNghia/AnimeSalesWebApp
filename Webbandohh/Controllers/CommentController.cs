using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbandohh.Models;
using Webbandohh.Servies;

namespace Webbandohh.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentServices db = new CommentServices();
        public ActionResult Index(int id)
        {
            var list = db.ListCommentByItemId(id);
            if (list != null)
            {
                return View(list);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreateDate = DateTime.Now;
                comment.IsActive = true;
                if (db.Insert(comment) == 1)
                {
                    return RedirectToAction("ItemDetail", "Home", new { id = comment.ItemId });
                }
                else
                {
                    ModelState.AddModelError("", "Comment empty");
                }
            }
            return RedirectToAction("ItemDetail", "Home", new { id = comment.ItemId });
        }
    }
}