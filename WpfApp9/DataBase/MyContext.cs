using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9.DataBase
{
    public class MyContext : DbContext
    {
        private string ConnectionString = "server=176.59.97.251; database=terrorblade; user id=sa; password=sa";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

        }
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }

    }
}
