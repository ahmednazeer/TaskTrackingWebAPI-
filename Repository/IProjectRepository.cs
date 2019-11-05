using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.Repository
{
    public interface IProjectRepository
    {
        ICollection<Project> getAllProjects();
    }
}
