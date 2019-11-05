using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web_API.Dtos;
using Web_API.Models;

namespace Web_API.Repository
{
    public interface ITaskReopsitory
    {
        ICollection<Task> getAllTasks();
        Task addTask(TaskDto model);
        bool editTask(Task task);
        Task removeTask(int taskId);
        Task getTaskDetails(int taskId);

    }
}
