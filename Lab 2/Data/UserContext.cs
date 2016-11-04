using Lab_2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lab_2.Data
{
    public class UserContext : DbContext
    {

        public UserContext() : base("UserContext")
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Group> Groups { get; set; }
    }
}