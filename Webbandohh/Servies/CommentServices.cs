using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Webbandohh.Repository;

namespace Webbandohh.Servies
{
    public class CommentServices
    {
        private IComment db;
        public CommentServices()
        {
            db = new CommentRepository(new ApplicationDbContext());
        }
        public int Insert(Comment t)
        {
            db.Insert(t);
            return db.Save();
        }
        public ICollection<Comment> GetAll()
        {
            return db.GetAll();
        }
        public IEnumerable<Comment> ListCommentByItemId(int id)
        {
            return db.ListCommentByItemId(id);
        }
    }
}