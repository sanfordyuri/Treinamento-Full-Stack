using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RXCrud.Data.Context
{
    public class DesignRXCrudContext : IDesignTimeDbContextFactory<RXCrudContext>
    {
        public RXCrudContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<RXCrudContext> builder = new DbContextOptionsBuilder<RXCrudContext>();
            builder.UseNpgsql("Host=127.0.0.1;Database=RXCrud;Username=postgres;Password=1234;");
            return new RXCrudContext(builder.Options);
        }
    }
}