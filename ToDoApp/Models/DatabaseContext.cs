using System;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
		{

		}

		public DbSet<ToDoModel> toDoApps { get; set; }
	}
}

