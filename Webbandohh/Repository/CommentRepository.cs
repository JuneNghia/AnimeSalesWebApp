using System;
using Webbandohh.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webbandohh.Repository
{
    public class CommentRepository: IComment
    {
        private ApplicationDbContext dBContext;
        public CommentRepository(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public ICollection<Comment> GetAll()
        {
            return dBContext.Comments.ToList();
        }

        public Comment GetById(object id)
        {
            return dBContext.Comments.Where(x => x.ItemId == Convert.ToInt32(id)).SingleOrDefault();
        }

        public ICollection<Comment> GetPartial()
        {
            return dBContext.Comments.Take(4).ToList();
        }

        public void Insert(Comment t)
        {
            dBContext.Comments.Add(t);
        }


        public void Update(Comment t)
        {
            dBContext.Entry<Comment>(t).State = System.Data.Entity.EntityState.Modified;
        }
        public int CountAll()
        {
            return dBContext.Comments.ToList().Count;
        }

        public void Delete(int id)
        {
            var cm = dBContext.Comments.Where(x => x.CommentId == id).SingleOrDefault();
        }
        public int Save()
        {
            return dBContext.SaveChanges();
        }

        public IEnumerable<Comment> ListAllPaging(string searh, int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<Comment> ListCommentByItemId(int id)
        {
            List<Comment> list = dBContext.Comments.Where(x => x.ItemId == id).ToList();
            return list;
        }
    }
}