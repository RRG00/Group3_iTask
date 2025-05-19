using iTasks.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace iTasks
{
    internal class ITaskContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Programmer> Programmers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TypeTask> TipeTasks { get; set; }
    }
     
}
   


