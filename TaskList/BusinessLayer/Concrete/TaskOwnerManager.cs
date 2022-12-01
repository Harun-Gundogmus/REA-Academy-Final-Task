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
    public class TaskOwnerManager : ITaskOwnerService
    {
        ITaskOwnerDal taskOwnerDal;
        public TaskOwnerManager(ITaskOwnerDal taskOwnerDal)
        {
            this.taskOwnerDal = taskOwnerDal;
        }

        public int AddTask(TaskOwner task)
        {
            return taskOwnerDal.Add(task);
        }

        public int DeleteTask(TaskOwner task)
        {
            return taskOwnerDal.Delete(task);
        }

        public List<TaskOwner> getAllTasks()
        {
            return taskOwnerDal.getAll();
        }

        public TaskOwner getTaskByID(int id)
        {
            return taskOwnerDal.getByID(id);
        }

        public int UpdateTask(TaskOwner task)
        {
            return taskOwnerDal.Update(task);
        }
    }
}
