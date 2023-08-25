using Business.Abstract;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment t)
        {
            _commentDal.Add(t);
        }

        public void Delete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment Get(int id)
        {
            return _commentDal.GetId(id);
        }

        public List<Comment> List()
        {
            return _commentDal.List();
        }

        public List<Comment> ListCommentWith()
        {
            return _commentDal.ListCommentWith();
        }

        public List<Comment> ListProductComment(int id)
        {
            return _commentDal.ListProductComment(id);
        }

        public List<Comment> ListUserComment(int id)
        {
            return _commentDal.ListUserComment(id);
        }

        public void Update(Comment t)
        {
            _commentDal.Update(t);
        }

        
    }
}
