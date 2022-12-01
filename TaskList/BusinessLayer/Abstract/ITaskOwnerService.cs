using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITaskOwnerService
    {
        int AddTask(TaskOwner task);
        int UpdateTask(TaskOwner task);
        int DeleteTask(TaskOwner task);
        TaskOwner getTaskByID (int id);
        List<TaskOwner> getAllTasks();
    }
}
