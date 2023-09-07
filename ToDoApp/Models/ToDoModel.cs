using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
	public class ToDoModel
	{
		[Key]
		public int id { get; set; }
		[Required]
        [DisplayName("Display Name")]
        public string? TaskName { get; set; }
		public string? TaskDescripion { get; set; }
        [DisplayName("Due Date")]
        public DateTime Date { get; set; }
	}
}

