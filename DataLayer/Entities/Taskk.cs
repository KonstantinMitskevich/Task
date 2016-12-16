using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Taskk
    {
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        [Display(Name = "Task")]
        [MaxLength(20, ErrorMessage = "Too many characters. No more than 20")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Task value is required.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public int Status { get; set; }

       // [Required]
        public int? ExecutorId { get; set; }
    }
}
