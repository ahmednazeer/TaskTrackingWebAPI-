using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using Web_API.Dtos;
using Web_API.Models;

namespace Web_API.Repository
{
    public class TaskRepository : ITaskReopsitory
    {
        private readonly DBContext context;

        public TaskRepository()
        {
            context = new DBContext();
        }
        public Task addTask(TaskDto model)
        {
            if (model != null)
            {
                Task task = new Task
                {
                    Title = model.Title,
                    Details = model.Details,
                    DeliveryDate = DateTime.Parse(model.DeliveryDate.ToString()),
                    AssigneeName = model.AssigneeName,
                    ProjectId = model.ProjectId
                };
                var taskResult= context.Tasks.Add(task);
                context.SaveChanges();
                return taskResult != null ? taskResult : null ;


            }
            else return null;
            //throw new NotImplementedException();
        }

        public bool editTask(Task task)
        {
            var taskResult = context.Tasks.SingleOrDefault(t => t.ID == task.ID);
            if (taskResult == null) return false;
            taskResult.DeliveryDate = task.DeliveryDate;
            taskResult.Title = task.Title;
            taskResult.ProjectId = task.ProjectId;
            taskResult.Details = task.Details;
            taskResult.AssigneeName = task.AssigneeName;
            context.SaveChanges();
            return true;
            //throw new NotImplementedException();
        }

        public ICollection<Task> getAllTasks()
        {
            var taskList = context.Tasks.ToList();
            return taskList;

        }

        public Task removeTask(int taskId)
        {
            var taskResult = context.Tasks.SingleOrDefault(task => task.ID == taskId);
            if (taskResult != null)
            {
                var result = context.Tasks.Remove(taskResult);
                context.SaveChanges();
                return result;
            }
            else return null;
        }
        public Task getTaskDetails(int taskId) {
            var taskResult = context.Tasks.Include("Project").SingleOrDefault(task => task.ID == taskId);
            return taskResult != null ? taskResult : null;
        
        }

    }
}