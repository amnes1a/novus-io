using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Novus.Authorization;

namespace Novus
{
    [DependsOn(
        typeof(NovusCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class NovusApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<NovusAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(NovusApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}
