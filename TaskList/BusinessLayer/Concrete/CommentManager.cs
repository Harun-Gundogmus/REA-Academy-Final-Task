using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            this.commentDal = commentDal;
        }

        public int AddComment(TaskComment taskComment)
        {
            return commentDal.Add(taskComment);
        }

        public int DeleteComment(TaskComment taskComment)
        {
            return commentDal.Delete(taskComment);
        }

        public List<TaskComment> GetAllComments()
        {
            return commentDal.getAll();
        }

        public TaskComment getCommentByID(int id)
        {
            return commentDal.getByID(id);
        }

        public int UpdateComment(TaskComment taskComment)
        {
            return commentDal.Update(taskComment);
        }
    }
}
