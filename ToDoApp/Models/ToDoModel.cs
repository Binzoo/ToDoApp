using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
	public class ToDoModel
	{
		[Key]
		public int id { get; set; }
		
        [DisplayName("Display Name")]
		[Required(ErrorMessage = "Task name is required")]
        public string? TaskName { get; set; }
		public string? TaskDescripion { get; set; }
        [DisplayName("Due Date")]
        [Required(ErrorMessage = "Due date is required")]
        public DateTime Date { get; set; }
	}
}

