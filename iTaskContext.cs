using iTasks.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks
{
    internal class iTaskContext : DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<Task> Tasks { get; set; }
       public DbSet<TipeTask> TipeTasks { get; set; }   
    }
}
