using Abp.Application.Navigation;
using Abp.Localization;
using Novus.Authorization;

namespace Novus.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class NovusNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Channels,
                        L("Channels"),
                        url: "Channels",
                        icon: "view_module",
                        requiresAuthentication: true
                    )
                );

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, NovusConsts.LocalizationSourceName);
        }
    }
}
