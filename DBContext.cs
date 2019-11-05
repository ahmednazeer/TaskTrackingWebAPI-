using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web_API.Models;

namespace Web_API
{
    public class DBContext:DbContext
    {
        public DBContext():base("conn")
        {

        }
        public DbSet<Task> Tasks { set; get; }
        public DbSet<Project> Projects { set; get; }
    }
}