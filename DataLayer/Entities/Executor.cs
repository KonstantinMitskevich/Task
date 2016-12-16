using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Executor
    {
        public int ExecutorId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(20, ErrorMessage = "Too many characters. No more than 20")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SurName is required.")]
        [MaxLength(20, ErrorMessage = "Too many characters. No more than 20")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        [MaxLength(20, ErrorMessage = "Too many characters. No more than 20")]
        public string LastName { get; set; }
    }
}
