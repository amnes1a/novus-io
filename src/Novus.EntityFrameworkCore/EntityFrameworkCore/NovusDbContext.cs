using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Novus.Authorization.Roles;
using Novus.Authorization.Users;
using Novus.Channels;
using Novus.MultiTenancy;

namespace Novus.EntityFrameworkCore
{
    public class NovusDbContext : AbpZeroDbContext<Tenant, Role, User, NovusDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        public virtual DbSet<Channel> Channels { get; set; }
        
        public NovusDbContext(DbContextOptions<NovusDbContext> options)
            : base(options)
        {
        }
    }
}
