using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        int AddComment(TaskComment taskComment);
        int DeleteComment(TaskComment taskComment);
        int UpdateComment(TaskComment taskComment);
        List<TaskComment> GetAllComments();
        TaskComment getCommentByID(int id);
    }
}
