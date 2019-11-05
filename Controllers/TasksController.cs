using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Web_API.Dtos;
using Web_API.Models;
using Web_API.Repository;

namespace Web_API.Controllers
{
    
    [RoutePrefix("api/tasks")]
    public class TasksController : ApiController
    {
        private readonly ITaskReopsitory iTaskRepository;
        public TasksController():this(new TaskRepository())
        {
        }

        public TasksController(ITaskReopsitory reopsitory)
        {
            iTaskRepository = reopsitory;
        }


        [Route("list")]//[Route("api/tasks/list")]
        [HttpGet]
        public IHttpActionResult GetAllTasks()
        {
            return Ok(iTaskRepository.getAllTasks());

        }


        [Route("details/{id}")]//[Route("api/tasks/get_task_details/{id}")]
        [HttpGet]
        public IHttpActionResult GetTaskById(int id)
        {
            var taskResult= iTaskRepository.getTaskDetails(id);

            if (taskResult != null) return Ok(taskResult);
            return BadRequest("Failed to get Task Details");
        }



        [Route("add")]//[Route("api/tasks/add")]
        [HttpPost]
        public IHttpActionResult PostTask(TaskDto model)
        {
            int x = 0;
            if (ModelState.IsValid)
            {
                var task= iTaskRepository.addTask(model);
                if (task == null)
                {
                    return BadRequest("Something wrong happened");
                }
                return Created("", task);
            }
            return BadRequest("Data Invalid");
                
        }



        [Route("update")]//[Route("api/tasks/update")]
        [HttpPut]
        public IHttpActionResult UpdateTask(Task model)
        {
            if (iTaskRepository.editTask(model))
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return BadRequest("Sothing wrong happened");
        }



        [Route("remove/{id}")]//[Route("api/{remove/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            var result= iTaskRepository.removeTask(id);
            if (result == null) return BadRequest("Failed to Delete Task");
            return Ok("Task Deleted Successfully");
        }

        

    }
}
