using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webbandohh.Models;

namespace Webbandohh.Repository
{
    public interface IComment : IRepository<Comment>
    {
        IEnumerable<Comment> ListCommentByItemId(int id);
    }
}