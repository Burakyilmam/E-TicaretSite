using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> ListProductComment(int id);
        List<Comment> ListUserComment(int id);
        List<Comment> ListCommentWith();
    }
}
