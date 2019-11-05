using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Task
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Task Title is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Task Details is Required")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Task Owner is Required")]
        public string AssigneeName { get; set; }
        [Required(ErrorMessage = "Task Project Field is Required")]

        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Task Date is Required")]

        public DateTime DeliveryDate { get; set; }
        public virtual Project Project { get; set; }

    }
}