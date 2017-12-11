using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Novus.EntityFrameworkCore
{
    public static class NovusDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NovusDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NovusDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
