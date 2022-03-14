using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RXCrud.Data.Context;
using RXCrud.NUnitTest.Infra;
using RXCrud.Service.AutoMapper;

namespace RXCrud.NUnitTest.Common
{
    public class Utilitarios
    {
        private static RXCrudContext _rxcrudContext;

        public static RXCrudContext GetContext()
        {
            if (_rxcrudContext == null)
            {
                DbContextOptions<RXCrudContext> dbContextOptions = new DbContextOptionsBuilder<RXCrudContext>()
                    .UseNpgsql("Host=127.0.0.1;Database=RXCrudTest;Username=postgres;Password=1234;")
                    .Options;

                _rxcrudContext = new RXCrudContext(dbContextOptions);
                RXCrudDBInitializer rxcrudDBInitializer = new RXCrudDBInitializer();
                rxcrudDBInitializer.Seed(_rxcrudContext);
            }

            return _rxcrudContext;
        }

        public static IMapper GetMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapping()));
            return mapperConfiguration.CreateMapper();
        }
    }
}