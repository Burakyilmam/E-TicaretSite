using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> ListProductComment(int id);
        List<Comment> ListUserComment(int id);
        List<Comment> ListCommentWith();
    }
}
