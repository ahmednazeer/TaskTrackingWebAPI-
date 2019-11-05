using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Dtos
{
    public class TaskDto
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string AssigneeName { get; set; }
        public int ProjectId { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}