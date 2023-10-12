using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase6.EF.Data.EF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Clase6.EF.Test.Comun
{
    public class TestBase
    {
        protected ServiceCollection Services { get; }
        protected ServiceProvider ServiceProvider { get; private set; }

        public TestBase()
        {
            Services = new ServiceCollection();

            Services.AddEntityFrameworkInMemoryDatabase();

            Services.AddDbContext<Pw32cIslaTesoroContext>((sp, options) =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseInternalServiceProvider(sp));

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
