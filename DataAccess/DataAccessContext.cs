using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessContext : DbContext
    {
        private readonly string _connectionString;

        public DataAccessContext()
        {
            _connectionString = Config.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);

        }
        public DbSet<Customer> Customer { get; set; }
    }
}
