using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JustDoItLater.Model
{
    public class AppDbContext : DbContext
    {
        //protected AppDbContext() : base()
        //{
        //    Database.EnsureCreated();
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

#if DEBUG
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasData(GetToDos());
            base.OnModelCreating(modelBuilder);
        }
        private List<ToDo> GetToDos()
        {
            return new List<ToDo> {
                new ToDo { Id=1, Title="Test", Date = DateTime.Now, Notes="Empty", CreationDate= DateTime.Now, State = Enums.ToDoState.NotStarted },
                new ToDo { Id=2, Title="Test2", Date = DateTime.Now, Notes="Empty2", CreationDate= DateTime.Now, State = Enums.ToDoState.InProgress },
                new ToDo { Id=3, Title="Test3", Date = DateTime.Now, Notes="Empty3", CreationDate= DateTime.Now, State = Enums.ToDoState.NotStarted },
            };
        }
#endif
        public DbSet<ToDo> ToDos { get; set; }
    }
}