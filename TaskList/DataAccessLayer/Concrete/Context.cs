using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-5ETPORJT;database=TaskListDB;integrated security=true;");
        }
        public DbSet<User> users { get; set; }
        public DbSet<TaskOwner> taskOwner { get; set; }
        public DbSet<TaskComment> Comment { get; set; }
    }
}