using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_API.Models;

namespace Web_API.Repository
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly DBContext context;
        public ProjectRepository()//:this(new ProjectRepository())
        {
            context = new DBContext();
        }


        public ICollection<Project> getAllProjects()
        {

            var projectResults = context.Projects.ToList();
            return projectResults;
            //throw new NotImplementedException();
        }
    }
}