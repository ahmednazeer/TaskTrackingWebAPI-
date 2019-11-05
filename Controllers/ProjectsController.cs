using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using Web_API.Repository;

namespace Web_API.Controllers
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        private readonly IProjectRepository projectRepository;
        public ProjectsController() : this(new ProjectRepository())
        {
        }
        public ProjectsController(IProjectRepository reopsitory)
        {
            projectRepository = reopsitory;
        }
        [Route("list")]
        [HttpGet]
        public IHttpActionResult Index()
        {
            var result = projectRepository.getAllProjects();
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Somthing wrong happened");
        }
    }
}