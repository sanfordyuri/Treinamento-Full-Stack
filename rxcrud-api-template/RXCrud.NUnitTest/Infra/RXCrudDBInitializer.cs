using Microsoft.EntityFrameworkCore;
using RXCrud.Data.Context;

namespace RXCrud.NUnitTest.Infra
{
    public class RXCrudDBInitializer
    {
        public RXCrudDBInitializer()
        {
        }

        public void Seed(RXCrudContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            context.SaveChanges();
        }
    }
}