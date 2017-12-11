using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Novus.Configuration;
using Novus.Web;

namespace Novus.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class NovusDbContextFactory : IDesignTimeDbContextFactory<NovusDbContext>
    {
        public NovusDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NovusDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            NovusDbContextConfigurer.Configure(builder, configuration.GetConnectionString(NovusConsts.ConnectionStringName));

            return new NovusDbContext(builder.Options);
        }
    }
}
