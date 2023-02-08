using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ClientDb");
        }
        public DbSet<ClientModel> Client { get; set; }
    }
}
